using EmpireQms.AdminModule.Api.Integration.Models;
using EmpireQms.Domain.Core.Events;

namespace EmpireQms.AdminModule.Api.Domain.Events.Terminals
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
