using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 观察者模式
{
    /// <summary>
    /// 老鼠
    /// </summary>
    class Mouse : IObserver
    {
        public void Handler()
        {
            this.Run();
        }

        public void Run()
        {
            Console.WriteLine($"老鼠跑了。。");
        }
    }
}
