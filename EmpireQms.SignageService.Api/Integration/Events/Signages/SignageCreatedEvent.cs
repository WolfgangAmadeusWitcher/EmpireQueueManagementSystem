using EmpireQms.Domain.Core.Events;
using EmpireQms.SignageService.Api.Domain.Models;

namespace EmpireQms.SignageService.Api.Integration.Events.Signages
{
    public class SignageCreatedEvent : Event
    {
        public Signage Signage { get; set; }
        public SignageCreatedEvent(Signage signage)
        {
            Signage = signage;
        }
    }
}
