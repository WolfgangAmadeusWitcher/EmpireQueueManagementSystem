using EmpireQms.Domain.Core.Bus;
using EmpireQms.Infra.Bus;
using EmpireQms.QueueService.Api.Application.Interfaces;
using EmpireQms.QueueService.Api.Application.Services;
using EmpireQms.QueueService.Api.Domain;
using EmpireQms.QueueService.Api.Domain.CommandHandlers.EmpireQueues;
using EmpireQms.QueueService.Api.Domain.CommandHandlers.Tickets;
using EmpireQms.QueueService.Api.Domain.Commands;
using EmpireQms.QueueService.Api.Domain.Commands.EmpireQueues;
using EmpireQms.QueueService.Api.Domain.Commands.Tickets;
using EmpireQms.QueueService.Api.Domain.Models;
using EmpireQms.QueueService.Api.Domain.Repositories;
using EmpireQms.QueueService.Api.Integration.EventHandlers.TerminalCategories;
using EmpireQms.QueueService.Api.Integration.EventHandlers.Terminals;
using EmpireQms.QueueService.Api.Integration.EventHandlers.TicketCategories;
using EmpireQms.QueueService.Api.Integration.EventHandlers.Tickets;
using EmpireQms.QueueService.Api.Integration.Events.TerminalCategories;
using EmpireQms.QueueService.Api.Integration.Events.Terminals;
using EmpireQms.QueueService.Api.Integration.Events.TicketCategories;
using EmpireQms.QueueService.Api.Integration.Events.Tickets;
using EmpireQms.QueueService.Api.Persistence;
using EmpireQms.QueueService.Api.Persistence.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace EmpireQms.QueueService.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddDbContext<QueueContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("EmpireQueueConnection"));
            });

            services.AddSwaggerGen(sg => sg.SwaggerDoc("v1", new OpenApiInfo { Title = "Empire Queue Management Service", Version = "v1.0" }));
            services.AddSignalR();
            services.AddMediatR(typeof(Startup));

            RegisterServices(services);
            RegisterCommands(services);
            RegisterRepositories(services);
            AddEventHandlers(services);
            services.AddControllers();
        }

        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory, "Queue Service");
            });

            services.AddTransient<IEmpireQueueService, EmpireQueueService>();

            services.AddTransient<TicketCreatedEventHandler>();
            services.AddTransient<TicketCategoryCreatedEventHandler>();
            services.AddTransient<TicketCategoryUpdatedEventHandler>();
            services.AddTransient<TicketCategoryDeletedEventHandler>();

            services.AddTransient<TerminalCategoryDeletedEventHandler>();
            services.AddTransient<TerminalCategoryCreatedEventHandler>();

            services.AddTransient<TerminalCreatedEventHandler>();
            services.AddTransient<TerminalDeletedEventHandler>();
        }

        private void RegisterCommands(IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<GetNextCustomerCommand, bool>, GetNextCustomerCommandHandler>();
            services.AddTransient<IRequestHandler<CompleteServiceForTerminalCommand, bool>, CompleteServiceForTerminalCommandHandler>();

            services.AddTransient<IRequestHandler<CreateEmpireQueueCommand, bool>, CreateEmpireQueueCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateEmpireQueueCommand, bool>, UpdateEmpireQueueCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteEmpireQueueCommand, bool>, DeleteEmpireQueueCommandHandler>();
        }

        private void RegisterRepositories(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IQueueRepository, QueueRepository>();
            services.AddTransient<ITicketRepository, TicketRepository>();
            services.AddTransient<ITerminalCategoryRepository, TerminalCategoryRepository>();
            services.AddTransient<ITicketCategoryRepository, TicketCategoryRepository>();
            services.AddTransient<ITerminalTicketRepository, TerminalTicketRepository>();
            services.AddTransient<ITerminalRepository, TerminalRepository>();
            services.AddTransient<QueueContext>();
        }

        public void AddEventHandlers(IServiceCollection services)
        {
            services.AddTransient<IEventHandler<TicketCreatedEvent>, TicketCreatedEventHandler>();

            services.AddTransient<IEventHandler<TicketCategoryCreatedEvent>, TicketCategoryCreatedEventHandler>();
            services.AddTransient<IEventHandler<TicketCategoryUpdatedEvent>, TicketCategoryUpdatedEventHandler>();
            services.AddTransient<IEventHandler<TicketCategoryDeletedEvent>, TicketCategoryDeletedEventHandler>();

            services.AddTransient<IEventHandler<TerminalCategoryCreatedEvent>, TerminalCategoryCreatedEventHandler>();
            services.AddTransient<IEventHandler<TerminalCategoryDeletedEvent>, TerminalCategoryDeletedEventHandler>();

            services.AddTransient<IEventHandler<TerminalCreatedEvent>, TerminalCreatedEventHandler>();
            services.AddTransient<IEventHandler<TerminalDeletedEvent>, TerminalDeletedEventHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            // global cors policy
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<EmpireQueueHub>("/empire-queue");
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(sui => sui.SwaggerEndpoint("/swagger/v1/swagger.json", "Empire Queue Management Service V1.0"));
            ConfigureEventBus(app);
        }

        private void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();

            eventBus.Subscribe<TicketCreatedEvent, TicketCreatedEventHandler>();

            eventBus.Subscribe<TicketCategoryCreatedEvent, TicketCategoryCreatedEventHandler>();
            eventBus.Subscribe<TicketCategoryUpdatedEvent, TicketCategoryUpdatedEventHandler>();
            eventBus.Subscribe<TicketCategoryDeletedEvent, TicketCategoryDeletedEventHandler>();

            eventBus.Subscribe<TerminalCategoryCreatedEvent, TerminalCategoryCreatedEventHandler>();
            eventBus.Subscribe<TerminalCategoryDeletedEvent, TerminalCategoryDeletedEventHandler>();

            eventBus.Subscribe<TerminalCreatedEvent, TerminalCreatedEventHandler>();
            eventBus.Subscribe<TerminalDeletedEvent, TerminalDeletedEventHandler>();
        }
    }
}
