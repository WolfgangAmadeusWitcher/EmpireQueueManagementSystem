using EmpireQms.AdminModule.Api.Domain.Models;
using EmpireQms.Domain.Core.Events;
using System.Collections.Generic;

namespace EmpireQms.AdminModule.Api.Integration.Events.Signages
{
    public class SignagesSyncedEvent : Event
    {
        public List<Signage> SignageTable { get; set; }
        public SignagesSyncedEvent(List<Signage> signage)
        {
            SignageTable = signage;
        }
    }
}
