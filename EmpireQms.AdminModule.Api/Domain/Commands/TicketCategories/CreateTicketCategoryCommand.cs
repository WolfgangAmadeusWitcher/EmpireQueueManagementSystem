using EmpireQms.AdminModule.Api.Domain.Models;

namespace EmpireQms.AdminModule.Api.Domain.Commands
{
    public class CreateTicketCategoryCommand : TicketCategoryCommand
    {
        public CreateTicketCategoryCommand(TicketCategory ticketCategory)
        {
            CommandedTicketCategory = ticketCategory;
        }
    }
}
