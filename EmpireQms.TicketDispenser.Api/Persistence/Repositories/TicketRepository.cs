using EmpireQms.TicketDispenser.Api.Domain.Models;
using EmpireQms.TicketDispenser.Api.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EmpireQms.TicketDispenser.Api.Persistence.Repositories
{
    public class TicketRepository : Repository<Ticket>, ITicketRepository
    {
        private TicketContext _ticketContext;

        public TicketRepository(TicketContext context) : base(context, context.Tickets)
        {
            _ticketContext = context;
        }
        public void UpdateTicket(Ticket ticket)
        {
            _ticketContext.Entry(ticket).State = EntityState.Modified;
            _ticketContext.SaveChanges();
        }
    }
}
