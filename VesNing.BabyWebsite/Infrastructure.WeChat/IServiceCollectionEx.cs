using Infrastructure.WeChat.IDAL;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Senparc.CO2NET.RegisterServices;
using Senparc.Weixin.RegisterServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.WeChat
{
    public static class IServiceCollectionEx
    {
        public static void AddWeChatSetting(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSenparcGlobalServices(configuration) //Senparc.CO2NET 全局注册
                .AddSenparcWeixinServices(configuration); //Senparc.Weixin 注册
            services.AddHttpClient();
            services.AddScoped<IWechatContext, WechatContext>();
        }
    }
}
