using Microsoft.AspNetCore.Mvc;
using Uzbekgram.Service.Dtos.Accounts;
using Uzbekgram.Service.Dtos.Verify;
using Uzbekgram.Service.Exceptions;
using Uzbekgram.Service.Interfaces.Verify;

namespace Uzbekgram.Web.Controllers
{
    [Route("verify")]
    public class VerifyController : Controller
    {
        private readonly IVerifyEmailService _verify;

        public VerifyController(IVerifyEmailService verifyEmailService)
        {
            this._verify = verifyEmailService;
        }
        [HttpGet("email")]
        public ViewResult VerifyEmail()
        {
            return View("VerifyEmail");
        }

        [HttpPost("email")]
        public async Task<IActionResult> VerifyAsync(VerifyEmailDto verifyEmailDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string token = await _verify.VerifyEmail(verifyEmailDto);
                    HttpContext.Response.Cookies.Append("X-Access-Token", token, new CookieOptions()
                    {
                        HttpOnly = true,
                        SameSite = SameSiteMode.Strict
                    });
                    return RedirectToAction("Index", "Home", new { area = "" });
                }
                catch (ModelErrorException modelError)
                {
                    ModelState.AddModelError(modelError.Property, modelError.Message);
                    TempData["email"] = verifyEmailDto.Email;
                    return RedirectToAction("VerifyEmail", "verify", new { area = "" });
                }
                catch
                {
                    TempData["email"] = verifyEmailDto.Email;
                    return RedirectToAction("VerifyEmail", "verify", new { area = "" });
                }
            }
            else
            {
                TempData["email"] = verifyEmailDto.Email;
                return RedirectToAction("VerifyEmail", "verify", new { area = "" });
            }
        }
    }
}
