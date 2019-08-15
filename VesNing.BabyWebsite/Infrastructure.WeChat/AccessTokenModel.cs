
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.WeChat
{
   internal class AccessTokenModel
    {
        public string AccessToken
        {
            get; set;
        }
        public DateTime GenerateTime
        {
            get;set;
        }
    }
}
