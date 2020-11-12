using EmpireQms.Printer.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpireQms.PrintService.Api.Domain.Repositories
{
    public interface IPrintTemplateRepository:IRepository<PrintTemplate>
    {
        void updataPrintTemplate(PrintTemplate printTemplate);
    }
}
