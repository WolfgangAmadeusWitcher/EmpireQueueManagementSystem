using EmpireQms.AdminModule.Api.Domain.Models;
using EmpireQms.Domain.Core.Commands;

namespace EmpireQms.AdminModule.Api.Domain.Commands
{
    public abstract class TicketCategoryCommand : Command
    {
        public TicketCategory CommandedTicketCategory { get; set; }

    }
}
