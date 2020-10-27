using EmpireQms.AdminModule.Api.Domain;
using EmpireQms.AdminModule.Api.Domain.Commands.Signages;
using EmpireQms.AdminModule.Api.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace EmpireQms.AdminModule.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SignageController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public SignageController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [Route("GetAll")]
        public ActionResult<IEnumerable<Signage>> Get()
        {
            return Ok(_unitOfWork.Signages.GetAll());
        }

        [HttpPost]
        [Route("Create")]
        public ActionResult<Signage> CreateSignage([FromBody] Signage signage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _unitOfWork.Signages.Create(signage);

                var createSignageCommand = new CreateSignageCommand(signage);
                _unitOfWork.SourceEvent(createSignageCommand);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return Ok(signage);
        }

        [HttpPost]
        [Route("Update")]
        public ActionResult<Signage> UpdateSignage([FromBody] Signage signage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _unitOfWork.Signages.UpdateSignage(signage);

                var updateSignageCommand = new UpdateSignageCommand(signage);
                _unitOfWork.SourceEvent(updateSignageCommand);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return Ok(signage);
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult DeleteSignage([FromBody] Signage signage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _unitOfWork.Signages.Delete(signage);


                var deleteSignageCommand = new DeleteSignageCommand(signage);
                _unitOfWork.SourceEvent(deleteSignageCommand);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return Ok(signage);
        }
    }
}
