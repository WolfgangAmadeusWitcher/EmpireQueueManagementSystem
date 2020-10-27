using EmpireQms.Domain.Core.Events;
using EmpireQms.SignageService.Api.Domain.Models;

namespace EmpireQms.SignageService.Api.Integration.Events.Signages
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
