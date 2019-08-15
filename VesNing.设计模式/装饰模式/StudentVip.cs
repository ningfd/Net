using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 装饰模式
{
    class StudentVip : AbstractStudent
    {
      
        public override void Study()
        {
            Console.WriteLine($"{this.ID+":"+this.Name+"==>VIP 学员每天晚上8点准时开始学习！"}");
        }
    }
}
