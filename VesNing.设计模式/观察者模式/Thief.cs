using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 观察者模式
{
    class Thief : IObserver
    {
        public void Handler()
        {
            this.Hide();
        }

        public void Hide()
        {
            Console.WriteLine("小偷藏起来。，");
        }
    }
}
