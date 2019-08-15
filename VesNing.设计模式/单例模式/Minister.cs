using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 单例模式
{
    class Minister
    {
        private string _name;
        private string _officialPosition;
        private string _talkContent;
        public Minister(string name,string officialPosition,string talkContent)
        {
            this._name = name;
            this._officialPosition = officialPosition;
            this._talkContent = talkContent;
        }
        public void Talk()
        {
            Console.WriteLine("汇报对象："+SingletonPattern.Instance.ToString());
            Console.WriteLine("汇报人：" + this._name + "；职位：" + this._officialPosition + "；汇报内容：" + _talkContent);
            Console.WriteLine("----------------------------------------------------------------------------");
        }
    }
}
