using EmpireQms.AdminModule.Api.Domain.Models;
using EmpireQms.Domain.Core.Events;

namespace EmpireQms.AdminModule.Api.Integration.Events.Signages
{
    public class SignageUpdatedEvent : Event
    {
        public Signage SignageInstance { get; set; }
        public SignageUpdatedEvent(Signage signage)
        {
            SignageInstance = signage;
        }
    }
}
