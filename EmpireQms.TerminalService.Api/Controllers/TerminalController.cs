using EmpireQms.TerminalService.Api.Domain;
using EmpireQms.TerminalService.Api.Domain.Commands;
using EmpireQms.TerminalService.Api.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EmpireQms.TerminalService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TerminalController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TerminalController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult<IEnumerable<Terminal>> Get()
        {
            return Ok(_unitOfWork.Terminals.GetAll());
        }
        [HttpGet]
        [Route("/Categories/GetAll")]
        public ActionResult<IEnumerable<TerminalCategory>> GetTerminalCategories()
        {
            return Ok(_unitOfWork.TerminalCategories.GetAll());
        }
        [HttpPost]
        [Route("Update")]
        public ActionResult<Terminal> UpdateTerminal([FromBody] Terminal terminal)
        {
            _unitOfWork.Terminals.UpdateTerminal(terminal);
            var updateTerminalStateCommand = new UpdateTerminalStateCommand(terminal);
            _unitOfWork.SourceEvent(updateTerminalStateCommand);
            _unitOfWork.BroadcastServerEvent("terminal-updated-event", terminal);
            return Ok(terminal);
        }
    }
}
