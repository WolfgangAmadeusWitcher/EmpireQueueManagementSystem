using EmpireQms.TerminalService.Api.Domain.Commands;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace EmpireQms.TerminalService.Api.Domain.Models
{
    public class TerminalHub : Hub
    {
        private readonly IUnitOfWork _unitOfWork;

        public TerminalHub(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnConnectedAsync();
        }

        private void UpdateTerminalState(Terminal terminal)
        {
            _unitOfWork.Terminals.UpdateTerminal(terminal);

            var updateTerminalCommand = new UpdateTerminalStateCommand(terminal);
            _unitOfWork.SourceEvent(updateTerminalCommand);
            Clients.All.SendAsync("terminal-updated-event", terminal);
        }

        private void UpdateBreakLog(BreakLogEntry breakLogEntry)
        {
            _unitOfWork.BreakLogEntries.UpdateBreakLogEntry(breakLogEntry);
            var updateBreakLogEntryCommand = new UpdateBreakLogEntryCommand(breakLogEntry);
            _unitOfWork.SourceEvent(updateBreakLogEntryCommand);
        }

        private void DisconnectFromTerminal(Terminal terminal)
        {
            if (terminal == null) return;
            terminal.Status = TerminalStatus.Offline;
            terminal.ConnectionId = string.Empty;

            UpdateTerminalState(terminal);
        }

        private void AddTerminalToConnectionContext(Terminal currentTerminal)
        {
            if (!Context.Items.ContainsKey(Context.ConnectionId))
                Context.Items.Add(Context.ConnectionId, currentTerminal);
            else
                Context.Items[Context.ConnectionId] = currentTerminal;
        }

        public void ActivateTerminal(Terminal currentTerminal)
        {
            AddTerminalToConnectionContext(currentTerminal);

            currentTerminal.ConnectionId = Context.ConnectionId;
            currentTerminal.Status = TerminalStatus.Online;

            UpdateTerminalState(currentTerminal);
        }
        public void RegisterTerminal(Terminal currentTerminal, Terminal oldTerminal)
        {
            ActivateTerminal(currentTerminal);
            DisconnectFromTerminal(oldTerminal);
        }
        private BreakLogEntry CreateBreakEntry(Terminal currentTerminal, string reasonText)
        {
            BreakLogEntry breakLog = new BreakLogEntry
            {
                BreakReason = reasonText,
                BreakStartTime = DateTime.Now,
                TerminalId = currentTerminal.Id,
                BreakState = BreakState.Open
            };

            _unitOfWork.BreakLogEntries.Create(breakLog);
            var breakLogCommand = new CreateBreakLogEntryCommand(breakLog);
            _unitOfWork.SourceEvent(breakLogCommand);
            return breakLog;
        }

        public BreakLogEntry EndBreak(Terminal currentTerminal, BreakLogEntry currentBreakLogEntry)
        {
            currentTerminal.ConnectionId = Context.ConnectionId;
            currentTerminal.Status = TerminalStatus.Online;
            currentBreakLogEntry.BreakEndTime = DateTime.Now;
            currentBreakLogEntry.BreakState = BreakState.Closed;
            UpdateBreakLog(currentBreakLogEntry);
            UpdateTerminalState(currentTerminal);
            return currentBreakLogEntry;
        }
        public BreakLogEntry TakeBreak(Terminal currentTerminal, string breakInfo)
        {
            currentTerminal.Status = TerminalStatus.Break;
            currentTerminal.ConnectionId = Context.ConnectionId;
            UpdateTerminalState(currentTerminal);
            var breakInstance = CreateBreakEntry(currentTerminal, breakInfo);
            return breakInstance;
        }
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var terminal = Context.Items[Context.ConnectionId];
            DisconnectFromTerminal(terminal as Terminal);
            Context.Items.Remove(Context.ConnectionId);
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnDisconnectedAsync(exception);
        }
    }
}
