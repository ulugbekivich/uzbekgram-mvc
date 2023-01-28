using Microsoft.AspNetCore.Mvc;
using Uzbekgram.Service.Dtos.Accounts;
using Uzbekgram.Service.Dtos.Verify;
using Uzbekgram.Service.Exceptions;
using Uzbekgram.Service.Interfaces.Accounts;
using Uzbekgram.Service.Interfaces.Verify;

namespace Uzbekgram.Web.Controllers
{
    [Route("accounts")]
    public class AccountsController : Controller
    {
        private readonly IAccountService _service;
        private readonly IVerifyEmailService _verify;

        public AccountsController(IAccountService acccountService,
                                  IVerifyEmailService verify)
        {
            this._service = acccountService;
            this._verify = verify;
        }

        [HttpGet("login")]
        public ViewResult Login()
        {
            return View("Login");
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(AccountLoginDto accountLoginDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    SendCodeToEmailDto sendCodeToEmailDto = new SendCodeToEmailDto()
                    {
                        Email = accountLoginDto.Email 
                    };
                    bool res = await _verify.SendCodeAsync(sendCodeToEmailDto);
                    if (res)
                    {
                        TempData["email"] = accountLoginDto.Email;
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
        }

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
                    try
                    {
                        SendCodeToEmailDto sendCodeToEmailDto = new SendCodeToEmailDto()
                        {
                            Email = accountRegisterDto.Email
                        };
                        bool res = await _verify.SendCodeAsync(sendCodeToEmailDto);
                        if (res)
                        {
                            TempData["email"] = accountRegisterDto.Email;
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
                else
                {
                    return Register();
                }
            }
            else return Register();
        }
    }
}
