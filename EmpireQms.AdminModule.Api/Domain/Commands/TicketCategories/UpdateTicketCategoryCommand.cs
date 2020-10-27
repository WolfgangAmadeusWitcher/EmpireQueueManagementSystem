using EmpireQms.AdminModule.Api.Domain.Models;

namespace EmpireQms.AdminModule.Api.Domain.Commands
{
    public class UpdateTicketCategoryCommand : TicketCategoryCommand
    {
        public UpdateTicketCategoryCommand(TicketCategory ticketCategory)
        {
            CommandedTicketCategory = ticketCategory;
        }
    }
}
