using EmpireQms.AdminModule.Api.Domain.Models;
using EmpireQms.Domain.Core.Commands;

namespace EmpireQms.AdminModule.Api.Domain.Commands.Signages
{
    public class UpdateSignageCommand : Command
    {
        public Signage Signage { get; set; }
        public UpdateSignageCommand(Signage signage)
        {
            Signage = signage;
        }
    }
}
