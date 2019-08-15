using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 观察者模式
{
    class Neighbor : IObserver
    {
        public void Handler()
        {
            this.Light();
        }

        public void Light()
        {
            Console.WriteLine("邻居开灯了。。");
        }
    }
}
