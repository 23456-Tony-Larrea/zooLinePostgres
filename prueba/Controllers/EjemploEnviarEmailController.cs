using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooLine.Models;
using ZooLine.Utilities;

namespace ZooLine.Controllers
{
    [Route("EmailHandler")]
    public class EjemploEnviarEmailController : Controller
    {
        private readonly IMailHandler _mailHandler;

        public EjemploEnviarEmailController(IMailHandler mailHandler)
        {
            _mailHandler = mailHandler;
        }

      
        // GET: EjemploEnviarEmailController
        [HttpGet("SendEmail")]
        public ActionResult SendEmail()
        {
           
            return View(new SendEmailModel());
        }

        [HttpPost("SendEmail")]
        public async Task<ActionResult> SendEmail([FromForm]SendEmailModel model)
        {
            if(!ModelState.IsValid)
            return View(model);

            model.Succes = await _mailHandler.SendEmailAsync(model);
            model.Content = string.Empty;

            return View(model);
        }



    }
}
