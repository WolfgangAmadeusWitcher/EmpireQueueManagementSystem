using EmpireQms.Domain.Core.Bus;
using EmpireQms.Printer.Api.Domain.Models;
using EmpireQms.PrintService.Api.Application.Services;
using EmpireQms.PrintService.Api.Domain;
using EmpireQms.PrintService.Api.Integration.Events.PrintTemplates;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace EmpireQms.PrintService.Api.Integration.EventHandlers.PrintTemplates
{
    public class PrintTemplateCreatedEventHandler : IEventHandler<PrintTemplateCreatedEvent>
    {

        private readonly IUnitOfWork _unitOfWork;
        public PrintTemplateCreatedEventHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task Handle(PrintTemplateCreatedEvent @event)
        {
            var createdPrintTemplate = new PrintTemplate
            {
                 PrintText=@event.PrintTemplate.PrintText
            };

            _unitOfWork.PrintTemplates.Create(createdPrintTemplate);

            var htmlParserService = new EmpireHtmlParserService(@event.PrintTemplate.PrintText);
            _ = new EmpirePrintService(htmlParserService.Parse());
            return Task.CompletedTask;
        }
    }
}
