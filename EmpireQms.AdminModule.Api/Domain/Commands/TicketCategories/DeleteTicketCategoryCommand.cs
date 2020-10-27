using EmpireQms.AdminModule.Api.Domain.Models;

namespace EmpireQms.AdminModule.Api.Domain.Commands
{
    public class DeleteTicketCategoryCommand : TicketCategoryCommand
    {
        public DeleteTicketCategoryCommand(TicketCategory ticketCategory)
        {
            CommandedTicketCategory = ticketCategory;
        }
    }
}
