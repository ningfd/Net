using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 观察者模式
{
    class Mother : IObserver
    {
        public void Handler()
        {
            this.Placate();
        }

        public void Placate()
        {
            Console.WriteLine("妈妈安抚。。");
        }
    }
}
