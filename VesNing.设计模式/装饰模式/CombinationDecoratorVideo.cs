using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 装饰模式
{
    internal class CombinationDecoratorVideo:CombinationBase
    {
        public CombinationDecoratorVideo(AbstractStudent student):base(student)
        {
            
        }
        public override void Study()
        {
            base.Study();
            Console.WriteLine("我要进行视频回放！");
        }
    }
}
