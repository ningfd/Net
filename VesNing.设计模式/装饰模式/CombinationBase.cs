using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 装饰模式
{
    class CombinationBase:AbstractStudent
    {
        public AbstractStudent abstractStudent;
        public CombinationBase(AbstractStudent student)
        {
            this.abstractStudent = student;
        }

        public override void Study()
        {
            this.abstractStudent.Study();
        }
    }
}
