using EmpireQms.Domain.Core.Events;
using EmpireQms.Monitoring.Api.Integration.Models;

namespace EmpireQms.Monitoring.Api.Integration.Events.Terminals
{
    public class TerminalSettingsUpdatedEvent : Event
    {
        public TerminalSettingUpdate TerminalSettingsUpdate { get; set; }
        public TerminalSettingsUpdatedEvent(TerminalSettingUpdate terminalSettingsUpdate)
        {
            TerminalSettingsUpdate = terminalSettingsUpdate;
        }
    }
}
