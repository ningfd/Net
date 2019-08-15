using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 观察者模式
{
    /// <summary>
    /// 爸爸
    /// 
    /// </summary>
    class Father:IObserver
    {
        public void Handler()
        {
            this.Rore();
        }

        public void Rore()
        {
            Console.WriteLine($"爸爸在咆哮。。");
        }
    }
}
