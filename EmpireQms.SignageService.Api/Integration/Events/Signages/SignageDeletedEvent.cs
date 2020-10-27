using EmpireQms.Domain.Core.Events;
using EmpireQms.SignageService.Api.Domain.Models;

namespace EmpireQms.SignageService.Api.Integration.Events.Signages
{
    public class SignageDeletedEvent : Event
    {
        public Signage SignageInstance { get; set; }
        public SignageDeletedEvent(Signage signage)
        {
            SignageInstance = signage;
        }
    }
}
