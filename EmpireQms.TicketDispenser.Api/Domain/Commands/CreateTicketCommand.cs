using EmpireQms.Domain.Core.Commands;
using EmpireQms.TicketDispenser.Api.Domain.Models;

namespace EmpireQms.TicketDispenser.Api.Domain.Commands
{
    public class CreateTicketCommand : Command
    {
        public Ticket Ticket { get; set; }
        public CreateTicketCommand(Ticket ticket)
        {
            Ticket = ticket;
        }
    }
}
