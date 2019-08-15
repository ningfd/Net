using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.WeChat.IDAL
{
    /// <summary>
    /// 微信组件的上下文菜单
    /// </summary>
    public interface IWechatContext
    {
        /// <summary>
        /// 由上游传递的微信相关信息
        /// </summary>
        WechatModel WechatModel
        {
            get; set;
        }
        IHttpContextAccessor HttpContextAccessor
        {
            get;
        }
        IHttpClientFactory HttpClientFactory
        {
            get;
        }
        Task<string> GetAccessToken();
    }
}
