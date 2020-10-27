using EmpireQms.TerminalService.Api.Domain;
using EmpireQms.TerminalService.Api.Domain.Commands;
using EmpireQms.TerminalService.Api.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EmpireQms.TerminalService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreakLogEntryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BreakLogEntryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("Create")]
        public ActionResult<BreakLogEntry> CreateBreakLogEntry([FromBody] BreakLogEntry breakLogEntry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _unitOfWork.BreakLogEntries.Create(breakLogEntry);

                var createBreakLogEntryCommand = new CreateBreakLogEntryCommand(breakLogEntry);
                _unitOfWork.SourceEvent(createBreakLogEntryCommand);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return Ok(breakLogEntry);
        }
    }
}
