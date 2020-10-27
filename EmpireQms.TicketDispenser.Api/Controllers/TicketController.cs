using EmpireQms.TicketDispenser.Api.Domain;
using EmpireQms.TicketDispenser.Api.Domain.Commands;
using EmpireQms.TicketDispenser.Api.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;

namespace EmpireQms.TicketDispenser.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public TicketController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("Create")]
        public ActionResult<Ticket> CreateTicket([FromBody] Ticket ticket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var empireQueue = _unitOfWork.EmpireQueues.Find(eq => eq.TicketCategoryId == ticket.TicketCategoryId).Single();
                var ticketCategory = _unitOfWork.TicketCategories.Get(ticket.TicketCategoryId);
                int lastNo = empireQueue.LastIssuedTicketNumber.GetValueOrDefault();

                ticket.TicketStatus = TicketStatus.Waiting;
                ticket.Number = GetNextNumber(lastNo, ticketCategory.FirstTicketNumber, ticketCategory.LastTicketNumber);
                ticket.CreatedDate = DateTime.Now;

                _unitOfWork.Tickets.Create(ticket);

                empireQueue.LastIssuedTicketNumber = ticket.Number;
                _unitOfWork.EmpireQueues.Update(empireQueue);

                var createTicketCommand = new CreateTicketCommand(ticket);
                _unitOfWork.SourceEvent(createTicketCommand);

                PrintTicketAsPdf(ticket);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return Ok(ticket);
        }

        private int GetNextNumber(int lastNumber, int categoryMin, int categoryMax)
        {
            if (lastNumber == 0) return categoryMin;
            if (lastNumber == categoryMax) return categoryMin;
            return ++lastNumber;
        }

        private void PrintTicketAsPdf(Ticket ticket)
        {
            string[] file = { ticket.Number.ToString(), ticket.CreatedDate.ToString() };

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "ticket.txt")))
            {
                foreach (string line in file)
                    outputFile.WriteLine(line);
            }
        }
    }
}
