using EmpireQms.Domain.Core.Events;
using EmpireQms.SignageService.Api.Domain.Models;
using System.Collections.Generic;

namespace EmpireQms.SignageService.Api.Integration.Events.Signages
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
