using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 装饰模式
{
    class Program
    {
        static void Main(string[] args)
        {
            //VIP学员 我要学习
            AbstractStudent vip = new StudentVip() { ID = "6666", Name="张三" };
         
            //现在呢 我不但要学习 而且我要 回看视频 编写代码 老师答疑，同时这三个顺序不一定
             vip = new CombinationDecoratorVideo(vip);
             vip = new CombinationDecoratorAnswer(vip);
             vip = new CombinationDecoratorCode(vip);
            vip.Study();

            Console.WriteLine("=========================================");
            SudentInheritCode student = new SudentInheritCode();
            student.Study();
            Console.ReadLine();
        }
    }
}
