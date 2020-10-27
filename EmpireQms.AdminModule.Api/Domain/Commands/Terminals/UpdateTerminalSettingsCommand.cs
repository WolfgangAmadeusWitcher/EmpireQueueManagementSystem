using EmpireQms.AdminModule.Api.Integration.Models;
using EmpireQms.Domain.Core.Commands;

namespace EmpireQms.AdminModule.Api.Domain.Commands.Terminals
{
    public class UpdateTerminalSettingsCommand : Command
    {
        public TerminalSettingUpdate TerminalSettings { get; set; }
        public UpdateTerminalSettingsCommand(TerminalSettingUpdate terminalSettingUpdate)
        {
            TerminalSettings = terminalSettingUpdate;
        }
    }
}
