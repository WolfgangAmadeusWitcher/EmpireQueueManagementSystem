using EmpireQms.AdminModule.Api.Domain.Commands.PrintTemplates;
using EmpireQms.AdminModule.Api.Integration.Events.PrintTemplates;
using EmpireQms.Domain.Core.Bus;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EmpireQms.AdminModule.Api.Domain.CommandHandlers.PrintTemplates
{
    public class CreatePrintTemplateCommandHandler : IRequestHandler<CreatePrintTemplateCommand, bool>
    {
        private readonly IEventBus _bus;

        public CreatePrintTemplateCommandHandler(IEventBus eventBus)
        {
            _bus = eventBus;
        }

        public Task<bool> Handle(CreatePrintTemplateCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new PrintTemplateCreatedEvent(request.PrintTemplate));
            return Task.FromResult(true);
        }
    }
}
