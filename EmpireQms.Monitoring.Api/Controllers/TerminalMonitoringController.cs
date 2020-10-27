using EmpireQms.Monitoring.Api.Domain;
using EmpireQms.Monitoring.Api.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EmpireQms.Monitoring.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TerminalMonitoringController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public TerminalMonitoringController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult<IEnumerable<Terminal>> Get()
        {
            return Ok(_unitOfWork.Terminals.GetAll());
        }
    }
}
