using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 单例模式
{
    /// <summary>
    /// 单例模式
    /// </summary>
    class SingletonPattern
    {
        //实例化对象
        private readonly static SingletonPattern obj = new SingletonPattern();
        /// <summary>
        /// 对外接口
        /// </summary>
        public static SingletonPattern Instance
        {
            get
            {
                return obj;
            }
        }
        /// <summary>
        /// 私有构造函数，内部产生
        /// </summary>
        private SingletonPattern()
        {

        }
        public override string ToString()
        {
            return "我是单例模式:"+GetHashCode();

        }
    }
}
