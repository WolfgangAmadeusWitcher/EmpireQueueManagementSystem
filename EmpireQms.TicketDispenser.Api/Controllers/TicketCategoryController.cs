using EmpireQms.TicketDispenser.Api.Domain;
using EmpireQms.TicketDispenser.Api.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EmpireQms.TicketDispenser.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketCategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public TicketCategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetCategories")]
        public ActionResult<IEnumerable<TicketCategory>> Get()
        {
            return Ok(_unitOfWork.TicketCategories.GetAll());
        }
    }
}
