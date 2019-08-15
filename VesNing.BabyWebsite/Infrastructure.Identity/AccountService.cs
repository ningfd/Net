using Infrastructure.Identity.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Infrastructure.Identity
{
    internal class AccountService : IAccountService
    {
        private UserManager<AppUser> UserManager;
        private SignInManager<AppUser> signInManager;
        private IHttpContextAccessor context;
        public AccountService(UserManager<AppUser> UserManager,
            SignInManager<AppUser> signInManager, IHttpContextAccessor context)
        {
            this.UserManager = UserManager;
            this.signInManager = signInManager;
            this.context = context;
        }
        public Task<bool> LoginAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<bool> RegisterAsync(RegisterViewModel model)
        {
            bool isSuccess = false;
            var appUser = new AppUser()
            {
                Email = model.Email,
                UserName = model.Email,
                PhoneNumber = model.phoneNumber
            };
            IdentityResult result = await this.UserManager.CreateAsync(appUser, model.Password);
            if (result.Succeeded)
            {
                await signInManager.SignInAsync(appUser, false);
                isSuccess = true;
            }
            return isSuccess;
        }
        public async Task<bool> SignAsync(string email, string passWord, bool rememeberMe)
        {
            bool result = false;
            AppUser user = await LoginAsync(email, passWord, rememeberMe);
            if (user != null)
            {
                Claim[] claims = new Claim[] {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email)
                };
                ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                await this.context.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                result = true;
            }
            return result;
        }
        private async Task<AppUser> LoginAsync(string email, string passWord, bool rememeberMe)
        {
            //bool user = false;
            //var _user=this.context.AppUsers.Where(w => w.Email == email).Select(l=>l);
            var user = await UserManager.FindByEmailAsync(email);
            SignInResult resultTask = await this.signInManager.PasswordSignInAsync(email, passWord, rememeberMe, false);
            if (!resultTask.Succeeded)
            {
                user = null;
            }
            return user;
        }

        public async Task<AppUser> GetCurrentUser()
        {
            AppUser user = null;
            if (this.context.HttpContext.User.Identity.IsAuthenticated)
            {
                user = await this.UserManager.GetUserAsync(this.context.HttpContext.User);
            }
            return user;
        }

        public async Task<AppUser> GetAppUserByEmail(string email)
        {
            return await this.UserManager.FindByEmailAsync(email);
        }
    }
}
