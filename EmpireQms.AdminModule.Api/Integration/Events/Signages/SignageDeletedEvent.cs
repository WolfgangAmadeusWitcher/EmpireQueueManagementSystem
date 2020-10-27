using EmpireQms.AdminModule.Api.Domain.Models;
using EmpireQms.Domain.Core.Events;

namespace EmpireQms.AdminModule.Api.Integration.Events.Signages
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
