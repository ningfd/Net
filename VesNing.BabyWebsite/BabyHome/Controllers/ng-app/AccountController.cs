using Infrastructure.Identity;
using Infrastructure.Identity.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    /// <summary>
    /// 处理注册登录
    /// </summary>
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private IAccountService service;
        public AccountController(IAccountService service)
        {
            this.service = service;

        }
        [HttpPost("register")]
        public bool Register([FromBody]RegisterViewModel register)
        {
            bool result = this.service.RegisterAsync(register).Result;
            return result;
        }
        [AllowAnonymous]
        [HttpGet("login")]
        public IActionResult Login(string returnUrl = null)
        {
            TempData["returnUrl"] = returnUrl;
            return View();
        }

        [HttpPost("login")]
        public async Task<string> LoginAsync([FromBody] LoginViewModel model, string returnUrl = null)
        {
            string result = "Success";
            AppUser user = service.GetAppUserByEmail(model.Email).Result;
            if (user == null)
            {
                return result = "AccountMiss";
            }
            bool isSuccess = await service.SignAsync(model.Email, model.Password, model.Remember);
            if (!isSuccess)
            {
                return result = "PassWordError";
            }
            return result;
        }
        [HttpGet("IsLogined")]
        public bool IsLogined()
        {
            if (this.service.GetCurrentUser().Result == null)
            {
                return false;
            }
            ; return true;
        }
    }
}
