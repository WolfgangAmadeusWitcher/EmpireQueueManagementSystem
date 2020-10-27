using EmpireQms.TerminalService.Api.Domain;
using EmpireQms.TerminalService.Api.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EmpireQms.TerminalService.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
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
    }
}
