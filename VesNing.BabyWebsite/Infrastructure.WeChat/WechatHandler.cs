using Infrastructure.WeChat.IDAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.Entities.Request;
using Senparc.Weixin.MP.MvcExtension;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.WeChat
{
    /// <summary>
    /// 微信对外处理
    /// </summary>
    public class WechatHandler: IWechatHandler
    {
        #region 字段定义
        private IHttpContextAccessor httpContext;
        //private IHttpClientFactory httpClientFactory;
        private WechatModel wechat;
        private IWechatContext wechatContext;

        ////token缓存键值对
        //private static Dictionary<string, string> tokenCache = new Dictionary<string, string>();
        #endregion

        #region 属性定义
        public WechatModel Wechat
        {
            get
            {
                return this.wechat;
            }
        }
        #endregion

        #region 构造函数
        public WechatHandler(IHttpContextAccessor httpContextAccessor, IWechatContext wechatContext)
        {
            this.httpContext = httpContextAccessor;
            this.wechatContext = wechatContext;
            //this.httpClientFactory = httpClientFactory;
            this.wechat = new WechatModel();
            this.wechatContext.WechatModel = this.wechat;
        }

        #endregion

        public ActionResult TokenValidate(string signature, string timestamp, string nonce, string echostr)
        {
            if (CheckSignature.Check(signature, timestamp, nonce, this.wechat.Token))
            {
                //验证成功之后 需要定义功能 菜单
                
                //返回随机字符串则表示验证通过
         
                return new WeixinResult(echostr);
            }
            else
            {
                return new WeixinResult($"failed:{signature}," +
                    $" {CheckSignature.GetSignature(timestamp, nonce, this.wechat.Token)}" +
                    $"。如果您在浏览器中看到这条信息，表明此Url可以填入微信后台。");
            }
        }

        public ActionResult WeChatRoute(PostModel postModel)
        {
            if (!CheckSignature.Check(postModel.Signature, postModel.Timestamp, postModel.Nonce, this.wechat.Token))
            {
               return new WeixinResult("参数错误");
            }
            postModel.Token = this.wechat.Token;
            postModel.EncodingAESKey = this.wechat.EncodingAESKey;
            postModel.AppId = this.wechat.AppId;

            var memory = new MemoryStream();
            this.httpContext.HttpContext.Request.Body.CopyTo(memory);

            CustomMessageHandler customMessageHandler = new CustomMessageHandler(memory,postModel);
            customMessageHandler.Execute();

            string token = this.wechatContext.GetAccessToken().Result;
            if (customMessageHandler.ResponseMessage is ResponseMessageText)
            {
                var messageText = customMessageHandler.ResponseMessage as ResponseMessageText;
                messageText.Content += $"  token:{token}";
            }
            return new FixWeixinBugWeixinResult(customMessageHandler);
            
        }

        //#region 获取Token
        //public async Task<string> GetAccessToken()
        //{
        //    string url = string.Format(@"https://api.weixin.qq.com/cgi-bin/token?grant_type={0}&appid={1}&secret={2}",
        //        this.wechat.Grant_Type, this.wechat.AppId, this.wechat.AppSecret);
        //    string token = await HttpGet(url);
        //    return token;
        //}
        //private async Task<string>  HttpGet(string url)
        //{
        //    HttpClient httpClient=this.httpClientFactory.CreateClient("weixinClient");
        //    HttpResponseMessage responseMessage =await httpClient.GetAsync(url);
        //    string json =await responseMessage.Content.ReadAsStringAsync();
        //    JObject result = JsonConvert.DeserializeObject(json) as JObject;
        //    string mesage = "";
        //    if (result.ContainsKey("errmsg"))
        //    {
        //        mesage = Convert.ToString(result["errmsg"]);
        //    }
        //    else if (result.ContainsKey("access_token"))
        //    {
        //        mesage = Convert.ToString(result["access_token"]);
        //    }
        //    return mesage;
        //}
        //#endregion
    }
}
