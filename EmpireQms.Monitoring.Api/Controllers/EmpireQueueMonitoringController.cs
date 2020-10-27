using EmpireQms.Monitoring.Api.Domain;
using EmpireQms.Monitoring.Api.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EmpireQms.Monitoring.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmpireQueueMonitoringController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public EmpireQueueMonitoringController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult<IEnumerable<EmpireQueue>> Get()
        {
            return Ok(_unitOfWork.EmpireQueues.GetAll());
        }
    }
}
