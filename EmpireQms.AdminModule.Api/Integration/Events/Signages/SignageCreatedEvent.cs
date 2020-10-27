using EmpireQms.AdminModule.Api.Domain.Models;
using EmpireQms.Domain.Core.Events;

namespace EmpireQms.AdminModule.Api.Integration.Events.Signages
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
