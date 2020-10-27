using EmpireQms.SignageService.Api.Domain;
using EmpireQms.SignageService.Api.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EmpireQms.SignageService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
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

        [HttpGet]
        [Route("GetTerminals")]
        public ActionResult<IEnumerable<Signage>> GetTerminals()
        {
            return Ok(_unitOfWork.Terminals.GetAll());
        }
    }
}
