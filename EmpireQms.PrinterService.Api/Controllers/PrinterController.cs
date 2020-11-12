using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpireQms.Printer.Api.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmpireQms.Printer.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PrinterController : ControllerBase
    {
        [HttpPost]
        [Route("CreateTemplate")]
        public ActionResult<PrintTemplate> CreateTemplate([FromBody] PrintTemplate printTemplate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
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

