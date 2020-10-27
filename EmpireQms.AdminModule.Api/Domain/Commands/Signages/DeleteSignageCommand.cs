using EmpireQms.AdminModule.Api.Domain.Models;
using EmpireQms.Domain.Core.Commands;

namespace EmpireQms.AdminModule.Api.Domain.Commands.Signages
{
    public class DeleteSignageCommand : Command
    {
        public Signage Signage { get; set; }
        public DeleteSignageCommand(Signage signage)
        {
            Signage = signage;
        }
    }
}
