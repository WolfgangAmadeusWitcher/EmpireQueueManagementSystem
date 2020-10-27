﻿using EmpireQms.Domain.Core.Bus;
using EmpireQms.TerminalService.Api.Domain;
using EmpireQms.TerminalService.Api.Domain.Commands;
using EmpireQms.TerminalService.Api.Domain.Models;
using EmpireQms.TerminalService.Api.Integration.Events.Terminals;
using System.Threading.Tasks;

namespace EmpireQms.TerminalService.Api.Integration.EventHandlers.Terminals
{
    public class NextPersonCalledEventHandler : IEventHandler<NextPersonCalledEvent>
    {
        private readonly IUnitOfWork _unitOfWork;

        public NextPersonCalledEventHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task Handle(NextPersonCalledEvent @event)
        {
            var updatedTerminal = _unitOfWork.Terminals.Get(@event.TerminalId);
            updatedTerminal.Status = TerminalStatus.Serving;
            _unitOfWork.Terminals.UpdateTerminal(updatedTerminal);
            UpdateTerminalStateCommand updateTerminalStateCommand = new UpdateTerminalStateCommand(updatedTerminal);
            _unitOfWork.SourceEvent(updateTerminalStateCommand);
            _unitOfWork.BroadcastServerEvent("terminal-updated-event", updatedTerminal);

            return Task.CompletedTask;
        }
    }
}
