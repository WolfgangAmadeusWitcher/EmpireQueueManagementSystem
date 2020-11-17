using EmpireQms.AdminModule.Api.Domain;
using EmpireQms.AdminModule.Api.Domain.Commands;
using EmpireQms.AdminModule.Api.Domain.Commands.TerminalCategories;
using EmpireQms.AdminModule.Api.Domain.Commands.TerminalRelatedObjects;
using EmpireQms.AdminModule.Api.Domain.Commands.Terminals;
using EmpireQms.AdminModule.Api.Domain.Models;
using EmpireQms.AdminModule.Api.Integration.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace EmpireQms.AdminModule.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
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

        [HttpPost]
        [Route("Create")]
        public ActionResult<Terminal> CreateTerminal([FromBody] Terminal terminal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                terminal.Status = TerminalStatus.Offline;
                _unitOfWork.Terminals.Create(terminal);

                var createTerminalCommand = new CreateTerminalCommand(terminal);
                _unitOfWork.SourceEvent(createTerminalCommand);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return Ok(terminal);
        }

        [HttpPost]
        [Route("Update")]
        public ActionResult<Terminal> UpdateTerminal([FromBody] Terminal terminal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _unitOfWork.Terminals.UpdateTerminal(terminal);
                
                var terminalSettingsUpdate = new TerminalSettingUpdate
                {
                    Alias = terminal.Alias,
                    TerminalId = terminal.Id
                };
                var updateTerminalCommand = new UpdateTerminalSettingsCommand(terminalSettingsUpdate);
                _unitOfWork.SourceEvent(updateTerminalCommand);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return Ok(terminal);
        }


        [HttpPost]
        [Route("Delete")]
        public IActionResult DeleteTerminal([FromBody] Terminal terminal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _unitOfWork.Terminals.Delete(terminal);

                var deleteTerminalCommand = new DeleteTerminalCommand(terminal);
                _unitOfWork.SourceEvent(deleteTerminalCommand);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return Ok(terminal);
        }

        [HttpPost]
        [Route("CreateTerminalCategory")]
        public ActionResult<TerminalCategory> InsertCategoryToTerminal([FromBody] TerminalCategory terminalCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _unitOfWork.Terminals.CreateTerminalCategory(terminalCategory);

                var createTerminalCategory = new CreateTerminalCategoryCommand(terminalCategory);
                _unitOfWork.SourceEvent(createTerminalCategory);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return Ok(terminalCategory);
        }

        [HttpPost]
        [Route("DeleteTerminalCategory")]
        public ActionResult<TerminalCategory> RemoveCategoryFromTerminal([FromBody] TerminalCategory terminalCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _unitOfWork.Terminals.DeleteTerminalCategory(terminalCategory);

                var deleteTerminalCategory = new DeleteTerminalCategoryCommand(terminalCategory);
                _unitOfWork.SourceEvent(deleteTerminalCategory);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return Ok(terminalCategory);
        }

        [HttpPost]
        [Route("CreateTerminalSignage")]
        public ActionResult<TerminalSignage> InsertSignageToTerminal([FromBody] TerminalSignage terminalSignage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _unitOfWork.Terminals.CreateTerminalSignage(terminalSignage);

                var createTerminalSignage = new CreateTerminalSignageCommand(terminalSignage);
                _unitOfWork.SourceEvent(createTerminalSignage);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return Ok(terminalSignage);
        }

        [HttpPost]
        [Route("DeleteTerminalSignage")]
        public ActionResult<TerminalSignage> RemoveSignageToTerminal([FromBody] TerminalSignage terminalSignage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _unitOfWork.Terminals.DeleteTerminalSignage(terminalSignage);

                var deleteTerminalSignage = new DeleteTerminalSignageCommand(terminalSignage);
                _unitOfWork.SourceEvent(deleteTerminalSignage);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return Ok(terminalSignage);
        }
    }
}
