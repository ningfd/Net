using Domain.IRepository;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.EntityFrameCore;
using Repository.EntityFrameCore.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using Infrastructure.Util;
using Infrastructure.WeChat.IDAL;
using Infrastructure.WeChat;
using System.Net.Http;

namespace BabyHome
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped<IJournalRepository, JournalRepository>();
            services.AddScoped<IBabyPhotoRepository, BabyPhotoRepository>();
            services.AddScoped<IWechatHandler, WechatHandler>();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
            //services.AddDbContext<AppIdentityContext>
            //    (options => options.UseSqlServer(Configuration.GetConnectionString("SqlServerConnection"),
            //    x => x.MigrationsAssembly("Infrastructure.Identity")));
            services.AddDbContext<EFDBContext>(ConfigHelper.GetDbConnection());
             //(options => options.UseMySQL(Configuration.GetConnectionString("SqlServerConnection")));
            /*
             identity相关信息
             */
            services.AddIdentitySetting();
            services.AddWeChatSetting(Configuration);
            /*
             在系统中注册服务IdentityServer,还会注册一个基于内存存储的运行状态
             AddDeveloperSigningCredential扩展在每次启动的时候，会为令牌签名创建了一个临时的密钥
             ，但是在生产环境需要一个持久密钥
             */
            //services.AddIdentityServer().AddDeveloperSigningCredential();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseDeveloperExceptionPage();
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            //注意app.UseAuthentication方法一定要放在下面的app.UseMvc方法前面，否者后面就算调用HttpContext.SignInAsync进行用户登录后，使用
            //HttpContext.User还是会显示用户没有登录，并且HttpContext.User.Claims读取不到登录用户的任何信息。
            //这说明Asp.Net OWIN框架中MiddleWare的调用顺序会对系统功能产生很大的影响，各个MiddleWare的调用顺序一定不能反
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";
                //spa.Options.DefaultPage = "/BabyWebsite/index.html";
                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
