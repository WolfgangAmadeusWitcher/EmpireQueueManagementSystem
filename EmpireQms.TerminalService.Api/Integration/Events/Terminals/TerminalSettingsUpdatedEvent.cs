using EmpireQms.Domain.Core.Events;
using EmpireQms.TerminalService.Api.Integration.Models;

namespace EmpireQms.TerminalService.Api.Integration.Events.Terminals
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
