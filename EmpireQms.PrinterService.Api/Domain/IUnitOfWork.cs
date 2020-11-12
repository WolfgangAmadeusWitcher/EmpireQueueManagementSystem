using EmpireQms.Domain.Core.Commands;
using EmpireQms.PrintService.Api.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpireQms.PrintService.Api.Domain
{
    public interface IUnitOfWork:IDisposable
    {
        public IPrintTemplateRepository PrintTemplates { get; }

        public void SourceEvent<T>(T command) where T : Command;
        int Complete();

    }
}
