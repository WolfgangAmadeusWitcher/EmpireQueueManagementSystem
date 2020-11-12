using EmpireQms.AdminModule.Api.Domain.Models;
using EmpireQms.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpireQms.AdminModule.Api.Domain.Commands.PrintTemplates
{
    public class CreatePrintTemplateCommand : Command
    {
        public PrintTemplate PrintTemplate { get; set; }

        public CreatePrintTemplateCommand(PrintTemplate printTemplate)
        {
            PrintTemplate = printTemplate;
        }
    }
}
