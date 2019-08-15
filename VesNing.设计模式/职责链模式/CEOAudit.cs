using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 装饰模式;

namespace 职责链模式
{
    /// <summary>
    /// CEO
    /// </summary>
    internal class CEOAudit : AbstractAudit
    {
        public CEOAudit(ApplyContext context):base(context)
        {
            //Console.WriteLine($"我是类:{ GetType().ToString()}");
        }
        public override void Audit()
        {
            //开发经理 - 部门主管 - 部门经理 - 总监 - CEO
            Console.WriteLine($"CEO-{this.Name}:通过");
        }
    }
}
