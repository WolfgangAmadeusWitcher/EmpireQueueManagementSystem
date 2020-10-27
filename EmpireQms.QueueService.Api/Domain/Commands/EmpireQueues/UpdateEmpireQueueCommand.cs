using EmpireQms.Domain.Core.Commands;
using EmpireQms.QueueService.Api.Domain.Models;

namespace EmpireQms.QueueService.Api.Domain.Commands.EmpireQueues
{
    public class UpdateEmpireQueueCommand : Command
    {
        public EmpireQueue EmpireQueue { get; set; }
        public UpdateEmpireQueueCommand(EmpireQueue empireQueue)
        {
            EmpireQueue = empireQueue;
        }
    }
}
