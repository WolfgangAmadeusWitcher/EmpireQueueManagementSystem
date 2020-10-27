using EmpireQms.AdminModule.Api.Domain;
using EmpireQms.AdminModule.Api.Domain.Commands;
using EmpireQms.AdminModule.Api.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace EmpireQms.AdminModule.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class TicketCategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TicketCategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        [Route("GetAll")]
        public ActionResult<IEnumerable<TicketCategory>> Get()
        {
            return Ok(_unitOfWork.TicketCategories.GetAll());
        }

        [HttpPost]
        [Route("Create")]
        public ActionResult<TicketCategory> PostTicketCategory([FromBody]TicketCategory ticketCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _unitOfWork.TicketCategories.Create(ticketCategory);

                var createTicketCategory = new CreateTicketCategoryCommand(ticketCategory);
                _unitOfWork.SourceEvent(createTicketCategory);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return Ok(ticketCategory);
        }

        [HttpPost]
        [Route("Update")]
        public ActionResult<TicketCategory> PutTicketCategory([FromBody]TicketCategory ticketCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _unitOfWork.TicketCategories.UpdateTicketCategory(ticketCategory);
                _unitOfWork.Complete();

                var updateTicketCategory = new UpdateTicketCategoryCommand(ticketCategory);
                _unitOfWork.SourceEvent(updateTicketCategory);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return Ok(ticketCategory);
        }


        [HttpPost]
        [Route("Delete")]
        public IActionResult DeleteTicketCategory([FromBody] TicketCategory ticketCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _unitOfWork.TicketCategories.Delete(ticketCategory);

                var deleteTicketCategoryCommand = new DeleteTicketCategoryCommand(ticketCategory);
                _unitOfWork.SourceEvent(deleteTicketCategoryCommand);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return Ok(ticketCategory);
        }
    }
}
