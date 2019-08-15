using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Identity
{
   public static class NIdentityExtend
    {
        public static void AddIdentitySetting(this IServiceCollection services)
        {
            //services.AddDbContext<AppIdentityContext>
            //   (options => options.UseSqlServer(connention,
            //   x => x.MigrationsAssembly("Infrastructure.Identity")));
            services.AddDbContext<AppIdentityContext>(Util.ConfigHelper.GetDbConnection());
              //(options => options.UseMySQL(connention));
            services.AddDefaultIdentity<AppUser>().
                AddEntityFrameworkStores<AppIdentityContext>().
                AddSignInManager();  
            services.AddScoped<IAccountService, AccountService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //注册认证服务
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
                AddCookie(options=> {
                    options.AccessDeniedPath = "/login";
                    options.LoginPath = "/login";
                });
        }
    }
}
