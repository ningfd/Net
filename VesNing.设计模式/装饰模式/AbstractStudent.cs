using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 装饰模式
{
   public abstract  class AbstractStudent
    {
        public string ID { get; set; }
        public string Name { get; set; }

        public abstract void Study();
    }
}
