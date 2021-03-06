﻿using EmpireQms.Domain.Core.Bus;
using EmpireQms.Monitoring.Api.Domain;
using EmpireQms.Monitoring.Api.Domain.Models;
using EmpireQms.Monitoring.Api.Integration.Events.BreakLogEntries;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace EmpireQms.Monitoring.Api.Integration.EventHandlers.BreakLogEntries
{
    public class BreakLogEntryCreatedEventHandler : IEventHandler<BreakLogEntryCreatedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHubContext<MonitoringHub> _hub;

        public BreakLogEntryCreatedEventHandler(IUnitOfWork unitOfWork, IHubContext<MonitoringHub> terminalHub)
        {
            _unitOfWork = unitOfWork;
            _hub = terminalHub;
        }

        public Task Handle(BreakLogEntryCreatedEvent @event)
        {
            var breakLogEntry = new BreakLogEntry
            {
                Id = @event.BreakLogEntryInstance.Id,
                BreakStartTime = @event.BreakLogEntryInstance.BreakStartTime,
                BreakEndTime = @event.BreakLogEntryInstance.BreakEndTime,
                BreakReason = @event.BreakLogEntryInstance.BreakReason,
                TerminalId = @event.BreakLogEntryInstance.TerminalId,
                BreakState = @event.BreakLogEntryInstance.BreakState
            };

            _unitOfWork.BreakLogEntries.Create(breakLogEntry);
            _hub.Clients.All.SendAsync("break-log-created-event", breakLogEntry);
            return Task.CompletedTask;
        }
    }
}
