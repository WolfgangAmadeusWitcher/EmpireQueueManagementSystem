using EmpireQms.Domain.Core.Bus;
using EmpireQms.Domain.Core.Commands;
using EmpireQms.PrintService.Api.Domain;
using EmpireQms.PrintService.Api.Domain.Repositories;
using EmpireQms.PrintService.Api.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpireQms.PrintService.Api.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PrintContext _context;
        private readonly IEventBus _eventBus;

        public IPrintTemplateRepository PrintTemplates { get; private set; }


        public UnitOfWork(PrintContext context, IEventBus eventBus)
        {
            _context = context;
            _eventBus = eventBus;
            PrintTemplates = new PrintTemplateRepository(context);
        }

        public void SourceEvent<T>(T command) where T : Command
        {
            _eventBus.SendCommand(command);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
       
    }
}
