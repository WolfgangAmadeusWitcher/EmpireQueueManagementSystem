using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpireQms.AdminModule.Api.Domain;
using EmpireQms.AdminModule.Api.Domain.Commands.PrintTemplates;
using EmpireQms.AdminModule.Api.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmpireQms.AdminModule.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PrintTemplateController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public PrintTemplateController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("SendPrintTemplate")]
        public ActionResult<PrintTemplate> SendPrintTemplate([FromBody] PrintTemplate printTemplate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                //_unitOfWork.Signages.Create(signage);

                var createPrintTemplateCommand = new CreatePrintTemplateCommand(printTemplate);
                _unitOfWork.SourceEvent(createPrintTemplateCommand);
                Console.WriteLine(printTemplate.PrintText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return Ok(printTemplate);
        }

    }
}
