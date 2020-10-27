using EmpireQms.QueueService.Api.Application.Interfaces;
using EmpireQms.QueueService.Api.Domain;
using EmpireQms.QueueService.Api.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;

namespace EmpireQms.Queue.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QueueController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private readonly IEmpireQueueService _empireQueueService;
        public QueueController(IUnitOfWork unitOfWork, IEmpireQueueService empireQueueService)
        {
            _unitOfWork = unitOfWork;
            _empireQueueService = empireQueueService;
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult<IEnumerable<EmpireQueue>> Get()
        {
            return Ok(_unitOfWork.EmpireQueues.GetAll());
        }

        [HttpPost]
        [Route("GetNext")]
        public ActionResult GetNextPerson([FromBody] int terminalId)
        {
            _empireQueueService.GetNextTicketForTerminal(terminalId);
            return Ok();
        }

        [HttpPost]
        [Route("EndService")]
        public ActionResult FinalizeService([FromBody] int terminalId)
        {
            var terminal = _unitOfWork.Terminals.Get(terminalId);
            _empireQueueService.EndOpenTicketTransaction(terminal);
            return Ok();
        }
    }
}
