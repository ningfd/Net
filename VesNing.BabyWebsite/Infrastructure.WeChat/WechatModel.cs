using System;

namespace Infrastructure.WeChat
{
    /// <summary>
    /// 微信相关信息
    /// </summary>
    public class WechatModel
    {
        private string _appSecret;
        private string grant_type;
        public WechatModel()
        {
            grant_type = "client_credential";
        }
        /// <summary>
        ///微信Token
        /// </summary>
        public string Token
        {
            get;set;
        }
        /// <summary>
        /// 微信公众号Id
        /// </summary>
        public string AppId
        {
            get;set;
        }
        public string EncodingAESKey
        {
            get;set;
        }
        public string Url
        {
            get;set;
        }
        public string Grant_Type
        {
            get { return this.grant_type; }
            set { this.grant_type = value; }
        }
        public string AppSecret
        {
            get;set;
        }
    }
}
