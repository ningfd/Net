using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace VesNing.EdutureCore.Util
{
    /// <summary>
    /// 配置文件读取
    /// 全局唯一   使用单例模式
    /// 单例模式继承问题：如果使用静态变量作为单例模式的话 无法支持继承
    ///                   如果需支持单例模式继承现在尝试使用泛型
    /// 
    /// </summary>
    public class ConfigFileUtil<T> where T:class
    {
        #region 字段定义
        protected IDictionary<string,string> configMap =new  Dictionary<string, string>();
        #endregion

        #region 静态变量-单例模式
        //通过使用静态变量实现单例模式 但是无法继承
        //private static readonly ConfigFileUtil instace = new ConfigFileUtil();
        //public ConfigFileUtil Current
        //{
        //    get { return instace; }
        //}

        #region 双锁实现单例
       
        private static T instance;
        private static object lockObj=new object();
        public static T Currnet
        {
            get
            {
                if (instance == null)
                {
                   lock(lockObj)
                    {
                        if (instance==null)
                        {
                            instance= Activator.CreateInstance(typeof(T),
                                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static,
                                null,null, CultureInfo.CurrentCulture) as T; 
                            
                        }
                    }
                }
                return instance;
            }
        }
        #endregion


        #endregion

        #region 构造函数
        protected ConfigFileUtil() { }
        #endregion

        #region 获取实例对象
       

        #endregion

        /// <summary>
        /// 增加配置文件的信息
        /// </summary>
        /// <param name="key">配置文件的key</param>
        /// <param name="configPath">配置文件路径</param>
        /// <returns></returns>
        public T AddFile(string key,string configPath)
        {
            if (configMap.Keys.Contains(key))
            {
                configMap[key] = configPath;
            }
            else
            {
                configMap.Add(key, configPath);
            }
            return instance;
        }
        public virtual T ReadConfig(string key)
        {
            return instance;
        }
        /// <summary>
        /// 读取配置节点
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="configNode"></param>
        /// <returns></returns>
        public virtual T GetValue<T>(string configNode)
        {
            return default(T);
        }
        /// <summary>
        /// 读取配置节点
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="configNode"></param>
        /// <returns></returns>
        public virtual string GetValue(string configNode)
        {
            return string.Empty;
        }

        public virtual void SetValue<T>(string configNode,string value)
        {

        }
    }
}
