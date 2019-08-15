using Infrastructure.WeChat.IDAL;
using Microsoft.AspNetCore.Mvc;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.Entities.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers.WeChat
{
    [Route("api/[controller]")]
    public class WeChatController:Controller
    {
        #region 字段定义
        //与微信公众账号后台的Token设置保持一致，区分大小写
        private readonly string Token = "vremembaby";
        private readonly string AppId = "wx828541810bd0cf5b";
        private readonly string EncodingAESKey = "zBuBQOavahrlLCeu8a5bbkD3YzYcsKBw496sC4EJ4Ks";
        private IWechatHandler wechatHandler;
        #endregion

        #region 构造函数
        public WeChatController(IWechatHandler wechatHandler)
        {
            this.wechatHandler = wechatHandler;
            this.wechatHandler.Wechat.Token = Token;
            this.wechatHandler.Wechat.AppId = AppId;
            this.wechatHandler.Wechat.EncodingAESKey = EncodingAESKey;
            this.wechatHandler.Wechat.AppSecret = "7a2e2dd7b3f3195a89eba4f254bd9c7d";
        }
        #endregion



        #region 微信token验证
        /// <summary>
        /// 微信后台验证地址（使用Get），微信后台的“接口配置信息”的Url填写
        /// 如：http://remembaby.natapp1.cc/api/wechat/process
        /// </summary>
        /// <param name="signature"></param>
        /// <param name="timestamp"></param>
        /// <param name="nonce"></param>
        /// <param name="echostr"></param>
        /// <returns></returns>
        [HttpGet("handle")]
        public ActionResult TokenValidate(string signature, string timestamp, string nonce, string echostr)
        {
            return this.wechatHandler.TokenValidate(signature,timestamp,nonce,echostr);
        }
        #endregion

        #region 微信Post请求
        /// <summary>
        /// 用户发送信息后，微信平台会自动Post一个请求到这里，并等待相应XML
        /// </summary>
        /// <param name="postModel"></param>
        /// <returns></returns>
        [HttpPost("handle")]
        public ActionResult WeChatRoute(PostModel postModel)
        {
            return this.wechatHandler.WeChatRoute(postModel);
        }
        #endregion
    }
}
