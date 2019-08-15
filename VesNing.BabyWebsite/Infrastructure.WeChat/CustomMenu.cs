using Infrastructure.WeChat.IDAL;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;

namespace Infrastructure.WeChat
{
    class CustomMenu
    {
        #region 字段定义
        private IWechatContext WechatContext;
        #endregion
        public CustomMenu(IWechatContext wechatContext)
        {
            this.WechatContext = wechatContext;
        }

        /// <summary>
        /// 创建功能菜单
        /// </summary>
        public async void CreateMenu()
        {
            string json = this.GetJson();
            //需要获取AccessToken
            string url = "https://api.weixin.qq.com/cgi-bin/menu/create?access_token=" + this.WechatContext.GetAccessToken();
            HttpClient httpClient = this.WechatContext.HttpClientFactory.CreateClient("WechatMeau");
            StringContent content = new StringContent(json, UTF8Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await httpClient.PostAsync(url, content);

        }
        private string GetJson()
        {
            FileStream fs = File.Open(Directory.GetCurrentDirectory() + @"\MenuJson.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("UTF-8"));
            string josn = sr.ReadToEnd();
            fs.Close();
            sr.Close();
            return josn;
        }
    }
}
