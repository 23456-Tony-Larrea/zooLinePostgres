using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ZooLine.Models;
using ZooLine.Utilities;
using Microsoft.AspNetCore.Authorization;
namespace ZooLine.Controllers
{
    [Authorize(Roles = "guia")]
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
