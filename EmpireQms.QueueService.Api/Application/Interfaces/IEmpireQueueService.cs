using EmpireQms.QueueService.Api.Domain.Models;

namespace EmpireQms.QueueService.Api.Application.Interfaces
{
    public interface IEmpireQueueService
    {
        void EndOpenTicketTransaction(Terminal terminal);
        Ticket GetNextTicketForTerminal(int terminalId);
    }
}
