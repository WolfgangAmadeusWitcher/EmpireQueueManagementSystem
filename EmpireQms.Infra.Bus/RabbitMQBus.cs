using MediatR;
using EmpireQms.Domain.Core.Events;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpireQms.Domain.Core.Commands;
using EmpireQms.Domain.Core.Bus;

namespace EmpireQms.Infra.Bus
{
    public sealed class RabbitMQBus : IEventBus
    {
        private readonly IMediator _mediator;
        private readonly Dictionary<string, List<Type>> _handlers = new Dictionary<string, List<Type>>();
        private readonly List<Type> _eventTypes = new List<Type>();
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly string _subscriberName;

        private const string _exchangeName = "direct"; 
        private const string _exchangeType = "direct";  

        public RabbitMQBus(IMediator mediator, IServiceScopeFactory serviceScopeFactory, string subsciberName)
        {
            _mediator = mediator;
            _serviceScopeFactory = serviceScopeFactory;
            _subscriberName = subsciberName;
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }

        public void Publish<T>(T @event) where T : Event
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var eventName = @event.GetType().Name;
                channel.ExchangeDeclare(exchange: _exchangeName, type: _exchangeType);


                var message = JsonConvert.SerializeObject(@event);
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: _exchangeName, routingKey: eventName, basicProperties: null, body: body);
            }
        }

        public void Subscribe<T, TH>()
            where T : Event
            where TH : IEventHandler<T>
        {
            var eventName = typeof(T).Name;
            var handlerType = typeof(TH);

            if (!_eventTypes.Contains(typeof(T)))
            {
                _eventTypes.Add(typeof(T));
            }

            if (!_handlers.ContainsKey(eventName))
            {
                _handlers.Add(eventName, new List<Type>());
            }

            if (_handlers[eventName].Any(eh => eh.GetType() == handlerType))
            {
                throw new ArgumentException($"Handler Type {handlerType.Name} is already registered for {eventName}", nameof(handlerType));
            }

            _handlers[eventName].Add(handlerType);

            StartBasicConsume<T>();
        }

        private void StartBasicConsume<T>() where T : Event
        {
            var factory = new ConnectionFactory() { HostName = "localhost", DispatchConsumersAsync = true };

            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            var eventName = typeof(T).Name;

            channel.ExchangeDeclare(exchange: _exchangeName, type: _exchangeType); 
            var queueName = channel.QueueDeclare(_subscriberName + "_" + eventName, false, false, false, null).QueueName; 
            channel.QueueBind(queue: queueName, exchange: _exchangeName, routingKey: eventName);

            var consumer = new AsyncEventingBasicConsumer(channel);

            consumer.Received += ConsumerReceived;
            channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer); 
        }

        private async Task ConsumerReceived(object sender, BasicDeliverEventArgs e)
        {
            var eventName = e.RoutingKey;
            var message = Encoding.UTF8.GetString(e.Body.ToArray());

            try
            {
                await ProcessEvent(eventName, message).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private async Task ProcessEvent(string eventName, string message)
        {
            if (_handlers.ContainsKey(eventName))
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var subscriptions = _handlers[eventName];
                    foreach (var subscription in subscriptions)
                    {
                        var handler = scope.ServiceProvider.GetService(subscription);
                        if (handler == null) continue;

                        var eventType = _eventTypes.SingleOrDefault(e => e.Name == eventName);
                        var concreteType = typeof(IEventHandler<>).MakeGenericType(eventType);

                        var @event = JsonConvert.DeserializeObject(message, eventType);

                        await (Task)concreteType.GetMethod("Handle").Invoke(handler, new object[] { @event });
                    }
                }
            }
            else
            {
                Console.WriteLine("Could not process Event because _handlers did not contain the eventname");
            }
        }
    }
}
