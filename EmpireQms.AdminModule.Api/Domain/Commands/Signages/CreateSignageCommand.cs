using EmpireQms.AdminModule.Api.Domain.Models;
using EmpireQms.Domain.Core.Commands;

namespace EmpireQms.AdminModule.Api.Domain.Commands.Signages
{
    public class CreateSignageCommand : Command
    {
        public Signage Signage { get; set; }
        public CreateSignageCommand(Signage signage)
        {
            Signage = signage;
        }
    }
}
