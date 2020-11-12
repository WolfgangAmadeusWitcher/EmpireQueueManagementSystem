using EmpireQms.Printer.Api.Domain.Models;
using EmpireQms.PrintService.Api.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpireQms.PrintService.Api.Persistence.Repositories
{
    public class PrintTemplateRepository:Repository<PrintTemplate>, IPrintTemplateRepository
    {
        private PrintContext _printContext;
        public PrintTemplateRepository(PrintContext context):base(context,context.PrintTemplates)
        {
            _printContext = context;
        }


        public void updataPrintTemplate(PrintTemplate printTemplate)
        {
            _printContext.Entry(printTemplate).State = EntityState.Modified;
            _printContext.SaveChanges();
        }
    }
}
