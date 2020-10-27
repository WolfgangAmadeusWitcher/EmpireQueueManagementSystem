using EmpireQms.AdminModule.Api.Domain.Models;
using EmpireQms.Domain.Core.Commands;
using System.Collections.Generic;

namespace EmpireQms.AdminModule.Api.Domain.Commands.Signages
{
    public class SyncSignagesCommand : Command
    {
        public List<Signage> SignageTable { get; set; }
        public SyncSignagesCommand(List<Signage> signages)
        {
            SignageTable = signages;
        }
    }
}
