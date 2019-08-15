using Infrastructure.Identity.ViewModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
   public interface IAccountService
    {
        Task<bool> SignAsync(string email, string passWord, bool rememeberMe);
        Task<bool> RegisterAsync(RegisterViewModel registerViewModel);
        Task<AppUser> GetCurrentUser();
        Task<AppUser> GetAppUserByEmail(string email);
    }
}
