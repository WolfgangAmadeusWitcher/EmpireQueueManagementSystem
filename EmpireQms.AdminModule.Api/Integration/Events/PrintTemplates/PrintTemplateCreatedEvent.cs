using EmpireQms.AdminModule.Api.Domain.Models;
using EmpireQms.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpireQms.AdminModule.Api.Integration.Events.PrintTemplates
{
    public class PrintTemplateCreatedEvent : Event
    {
        public PrintTemplate PrintTemplate { get; set; }
        public PrintTemplateCreatedEvent(PrintTemplate printTemplate)
        {
            PrintTemplate = printTemplate;
        }
    }
}
