using EmpireQms.Domain.Core.Events;
using EmpireQms.SignageService.Api.Integration.Models;

namespace EmpireQms.SignageService.Api.Integration.Events.Terminals
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
