using Microsoft.AspNetCore.Mvc;
using Senparc.Weixin.MP.Entities.Request;
using Senparc.Weixin.MP.MvcExtension;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.WeChat.IDAL
{
  public interface IWechatHandler
    {
        WechatModel Wechat
        {
            get;
        }
        /// <summary>
        /// 微信校验
        /// </summary>
        /// <param name="signature"></param>
        /// <param name="timestamp"></param>
        /// <param name="nonce"></param>
        /// <param name="echostr"></param>
        /// <returns></returns>
        ActionResult TokenValidate(string signature, string timestamp, string nonce, string echostr);
        ActionResult WeChatRoute(PostModel postModel);
    }
}
