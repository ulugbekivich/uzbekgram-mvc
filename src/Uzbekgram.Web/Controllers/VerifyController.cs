using Microsoft.AspNetCore.Mvc;

namespace Uzbekgram.Web.Controllers
{
    [Route("verify")]
    public class VerifyController : Controller
    {
        [HttpGet("email")]
        public ViewResult VerifyEmail()
        {
            return View("VerifyEmail");
        }
    }
}
