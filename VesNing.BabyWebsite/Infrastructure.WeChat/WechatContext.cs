using Infrastructure.WeChat.IDAL;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Senparc.Weixin.MP.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.WeChat
{
    class WechatContext : IWechatContext
    {
        #region 字段定义
        private IHttpContextAccessor httpContextAccessor;
        private IHttpClientFactory httpClientFactory;
        //token缓存键值对
        private static Dictionary<string, AccessTokenModel> tokenCache = new Dictionary<string, AccessTokenModel>();
        #endregion

        #region 构造函数
        public WechatContext(IHttpContextAccessor httpContextAccessor, IHttpClientFactory httpClientFactory)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.httpClientFactory = httpClientFactory;
        }
        #endregion

        #region 接口实现
        public WechatModel WechatModel
        { get; set; }
        public IHttpContextAccessor HttpContextAccessor
        {
            get { return this.httpContextAccessor; }
        }
        public IHttpClientFactory HttpClientFactory
        {
            get { return this.httpClientFactory; }
        }
        public async Task<string> GetAccessToken()
        {
            string result = "";
            string appid = this.WechatModel.AppId;
            //判断缓存是否存在键：appid，就将缓存中的token赋给result
            if (tokenCache.ContainsKey(appid))
            {
                result = tokenCache[appid].AccessToken;
            }
            //不存在则获取token
            if (string.IsNullOrEmpty(result))
            {
                result = await RequestAccessToken();
                //生成access_token的时间
                AccessTokenModel accessTokenModel = new AccessTokenModel()
                { AccessToken = result, GenerateTime = DateTime.Now };

                tokenCache.Add(appid, accessTokenModel);
            }
            //判断是否在有效期内，过期重新获取token
            else if (System.DateTime.Compare(tokenCache[appid].GenerateTime.AddSeconds(7200), System.DateTime.Now) < 0)
            {
                result = await RequestAccessToken();
                tokenCache[appid].AccessToken = result;
                tokenCache[appid].GenerateTime = System.DateTime.Now;
            }
            return result;
        }
        #endregion

        #region 私有方法
        private async Task<string> RequestAccessToken()
        {
            string url = string.Format(@"https://api.weixin.qq.com/cgi-bin/token?grant_type={0}&appid={1}&secret={2}",
             this.WechatModel.Grant_Type, this.WechatModel.AppId, this.WechatModel.AppSecret);
            string token = await HttpGet(url);
            return token;
        }
        private async Task<string> HttpGet(string url)
        {
            HttpClient httpClient = this.httpClientFactory.CreateClient("weixinClient");
            HttpResponseMessage responseMessage = await httpClient.GetAsync(url);
            string json = await responseMessage.Content.ReadAsStringAsync();
            JObject result = JsonConvert.DeserializeObject(json) as JObject;
            string mesage = "";
            if (result.ContainsKey("errmsg"))
            {
                mesage = Convert.ToString(result["errmsg"]);
            }
            else if (result.ContainsKey("access_token"))
            {
                mesage = Convert.ToString(result["access_token"]);
            }
            return mesage;
        }
        #endregion
    }
}
