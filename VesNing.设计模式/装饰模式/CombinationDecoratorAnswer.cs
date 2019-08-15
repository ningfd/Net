using System;

namespace 装饰模式
{
    internal class CombinationDecoratorAnswer : CombinationBase
    {
        public CombinationDecoratorAnswer(AbstractStudent student) : base(student)
        {

        }
        public override void Study()
        {
            base.Study();
            Console.WriteLine("老师答疑！");
        }
    }
}
