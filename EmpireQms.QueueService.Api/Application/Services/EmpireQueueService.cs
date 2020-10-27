using EmpireQms.QueueService.Api.Application.Interfaces;
using EmpireQms.QueueService.Api.Domain;
using EmpireQms.QueueService.Api.Domain.Commands;
using EmpireQms.QueueService.Api.Domain.Commands.EmpireQueues;
using EmpireQms.QueueService.Api.Domain.Commands.Tickets;
using EmpireQms.QueueService.Api.Domain.Models;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace EmpireQms.QueueService.Api.Application.Services
{
    public class EmpireQueueService : IEmpireQueueService
    {
        private readonly IUnitOfWork _unitOfWork;
        private static readonly object _object = new object();
        public EmpireQueueService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void EndOpenTicketTransaction(Terminal terminal)
        {
            if(terminal.TicketId == null) return;

            var openTicket = _unitOfWork.Tickets.Get(terminal.TicketId.GetValueOrDefault());

            openTicket.TicketStatus = TicketStatus.Served;
            openTicket.ServiceCompletedDate = DateTime.Now;

            _unitOfWork.Tickets.UpdateTicket(openTicket);

            terminal.TicketId = null;
            _unitOfWork.Terminals.UpdateTerminal(terminal);
            StartCompleteServiceForTerminalCommand(terminal.Id);
        }

        public Ticket GetNextTicketForTerminal(int terminalId)
        {
            Monitor.Enter(_object);
            var terminal = _unitOfWork.Terminals.Get(terminalId);
            EndOpenTicketTransaction(terminal);
            var ticketCategoriesForTerminal = _unitOfWork.TerminalCategories.Find(tc => tc.TerminalId == terminalId).ToList();
            var candidates = new List<Ticket>();
            foreach (var terminalCategory in ticketCategoriesForTerminal)
            {
                var selectedQueue = _unitOfWork.EmpireQueues.Find(eq => eq.TicketCategoryId == terminalCategory.TicketCategoryId).SingleOrDefault();
                if (selectedQueue == null || selectedQueue.ActiveWaitersCount == 0) continue;

                var waiters = _unitOfWork.Tickets.Find(t => t.TicketCategoryId == terminalCategory.TicketCategoryId && t.TicketStatus == TicketStatus.Waiting).ToList();
                candidates.Add(waiters.MinBy(w => w.CreatedDate).Single());
            }

            var result = new List<Ticket>();
            result.AddRange(candidates.MinBy(c => c.CreatedDate));

            var nextTicket = result.SingleOrDefault();

            if(nextTicket == null)
            {
                Monitor.Exit(_object);
                return null;
            }

            SetNextTicketStatus(nextTicket, terminal);
            DecreaseWaitersCountForEmpireQueue(nextTicket.QueueId);
            Monitor.Exit(_object);
            StartGetNextCustomerCommand(nextTicket, terminalId);
            return nextTicket;
        }

        private void DecreaseWaitersCountForEmpireQueue(int queueId)
        {
            var ticketQueue = _unitOfWork.EmpireQueues.Get(queueId);
            ticketQueue.ActiveWaitersCount--;
            _unitOfWork.EmpireQueues.UpdateQueue(ticketQueue);
            StartUpdateEmpireQueueCommand(ticketQueue);
            _unitOfWork.BroadcastServerEvent("empire-queue-updated-event", ticketQueue);
        }

        private void SetNextTicketStatus(Ticket nextTicket, Terminal terminal)
        {
            nextTicket.TicketStatus = TicketStatus.Called;
            _unitOfWork.Tickets.UpdateTicket(nextTicket);
            _unitOfWork.TerminalTickets.Create(new TerminalTicket { TerminalId = terminal.Id, TicketId = nextTicket.Id });
            terminal.TicketId = nextTicket.Id;
            _unitOfWork.Terminals.UpdateTerminal(terminal);
        }

        private void StartGetNextCustomerCommand(Ticket nextTicket, int terminalId)
        {
            var getNextCustomerCommand = new GetNextCustomerCommand(nextTicket, terminalId);
            _unitOfWork.SourceEvent(getNextCustomerCommand);
        }

        private void StartCompleteServiceForTerminalCommand(int terminalId)
        {
            var completeServiceForTerminalCommand = new CompleteServiceForTerminalCommand(terminalId);
            _unitOfWork.SourceEvent(completeServiceForTerminalCommand);
        }

        private void StartUpdateEmpireQueueCommand(EmpireQueue empireQueue)
        {
            var updateEmpireQueueCommand = new UpdateEmpireQueueCommand(empireQueue);
            _unitOfWork.SourceEvent(updateEmpireQueueCommand);
        }
    }
}
