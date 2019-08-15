using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 装饰模式
{
    class SudentInherit : AbstractStudent
    {
        public override void Study()
        {
            Console.WriteLine($"{this.ID + ":" + this.Name + "==>VIP 学员每天晚上8点准时开始学习！"}");
        }
    }

    class SudentInheritVideo : SudentInherit
    {
        public override void Study()
        {
            base.Study();
            Console.WriteLine("我要进行视频回放！");
        }
    }
    class SudentInheritAnswer : SudentInheritVideo
    {
        public override void Study()
        {
            base.Study();
            Console.WriteLine("老师答疑！");
        }
    }
    class SudentInheritCode : SudentInheritAnswer
    {
        public override void Study()
        {
            base.Study();
            Console.WriteLine("代码练习！");
        }
    }
}
