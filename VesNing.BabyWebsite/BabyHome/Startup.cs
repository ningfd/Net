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
             identity�����Ϣ
             */
            services.AddIdentitySetting();
            services.AddWeChatSetting(Configuration);
            /*
             ��ϵͳ��ע�����IdentityServer,����ע��һ�������ڴ�洢������״̬
             AddDeveloperSigningCredential��չ��ÿ��������ʱ�򣬻�Ϊ����ǩ��������һ����ʱ����Կ
             ������������������Ҫһ���־���Կ
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
            //ע��app.UseAuthentication����һ��Ҫ���������app.UseMvc����ǰ�棬���ߺ���������HttpContext.SignInAsync�����û���¼��ʹ��
            //HttpContext.User���ǻ���ʾ�û�û�е�¼������HttpContext.User.Claims��ȡ������¼�û����κ���Ϣ��
            //��˵��Asp.Net OWIN�����MiddleWare�ĵ���˳����ϵͳ���ܲ����ܴ��Ӱ�죬����MiddleWare�ĵ���˳��һ�����ܷ�
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
