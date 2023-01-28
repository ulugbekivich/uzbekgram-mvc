using Microsoft.AspNetCore.Mvc;
using Uzbekgram.Service.Dtos.Accounts;
using Uzbekgram.Service.Interfaces.Accounts;

namespace Uzbekgram.Web.Controllers
{
    [Route("accounts")]
    public class AccountsController : Controller
    {
        private readonly IAccountService _service;
        public AccountsController(IAccountService acccountService)
        {
            this._service = acccountService;
        }

        [HttpGet("login")]
        public ViewResult Login()
        {
            return View("Login");
        }

        /*[HttpPost("login")]
        public async Task<IActionResult> LoginAsync(AccountLoginDto accountLoginDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    SendToPhoneNumberDto sendToPhoneNumberDto = new SendToPhoneNumberDto()
                    {
                        PhoneNumber = accountLoginDto.PhoneNumber,
                    };
                    bool res = await _verify.SendCodeAsync(sendToPhoneNumberDto);
                    if (res)
                    {
                        TempData["tel"] = accountLoginDto.PhoneNumber;
                        return RedirectToAction("VerifyEmail", "verify", new { area = "" });
                    }
                    else
                    {
                        return Login();
                    }
                }
                catch (ModelErrorException modelError)
                {
                    ModelState.AddModelError(modelError.Property, modelError.Message);
                    return Login();
                }
                catch
                {
                    return Login();
                }
            }
            else return Login();
        }*/

        [HttpGet("register")]
        public ViewResult Register()
        {
            return View("Register");
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(AccountRegisterDto accountRegisterDto)
        {
            if (ModelState.IsValid)
            {
                bool result = await _service.AccountRegisterAsync(accountRegisterDto);
                if (result)
                {
                    return RedirectToAction("login", "accounts", new { area = "" });
                }
                else
                {
                    return Register();
                }
            }
            else return Register();
        }
    }
}
