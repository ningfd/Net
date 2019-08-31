
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace VesNing.EdutureCore.Util
{
    public class JsonConifgUtil : ConfigFileUtil<JsonConifgUtil>
    {
        #region 字段定义
        private JObject jObject;
        #endregion

        #region 构造函数
        private JsonConifgUtil()
        {

        }
        #endregion

        #region 重写方法
        public override JsonConifgUtil ReadConfig(string key)
        {
            string result = string.Empty;
            if (!this.configMap.Keys.Contains(key))
            {
                return this;
            }
            string path = AppDomain.CurrentDomain.BaseDirectory +configMap[key];
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"文件没有找到,{path}", path);
            }
            using (System.IO.StreamReader file = File.OpenText(path))
            {
                using (JsonTextReader jsonTextReader = new JsonTextReader(file))
                {
                    jObject = JObject.Load(jsonTextReader);

                }
            }
            return this;
        }
        /// <summary>
        /// 获取参数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="configNode"></param>
        /// <returns></returns>
        public override T GetValue<T>(string configNode)
        {
            JToken value = this.jObject.SelectToken(configNode);
            return JsonConvert.DeserializeObject<T>(value.ToString());
        }
        #endregion

        public override string GetValue(string configNode)
        {
            return this.jObject.SelectToken(configNode).ToString();
        }


    }
}
