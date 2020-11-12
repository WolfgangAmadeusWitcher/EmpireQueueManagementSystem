using EmpireQms.Domain.Core.Events;
using EmpireQms.Printer.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpireQms.PrintService.Api.Integration.Events.PrintTemplates
{
    public class PrintTemplateCreatedEvent:Event
    {
        public PrintTemplate PrintTemplate { get; set; }

        public PrintTemplateCreatedEvent(PrintTemplate printTemplate)
        {
            PrintTemplate = printTemplate;
        }
    }
}
