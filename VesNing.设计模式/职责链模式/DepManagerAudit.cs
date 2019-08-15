using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 职责链模式;

namespace 装饰模式
{
    /// <summary>
    /// 部门经理
    /// </summary>
    class DepManagerAudit : AbstractAudit
    {
        public DepManagerAudit(ApplyContext context):base(context)
        {
            //Console.WriteLine($"我是类:{ GetType().ToString()}");
        }
        public override void Audit()
        {
            if (this.Context.ApplyDay <= 10)
            {
                Console.WriteLine($"部门经理-{this.Name}:通过");
            }
            else
            {
                //开发经理 - 部门主管 - 部门经理 - 总监 - CEO
                Console.WriteLine($"我是{this.Name},我没审批权限，交由下一审批人");
                //MajordomoAudit charge = new MajordomoAudit(Context) { ID = "04", Name = "总监孙" };
                //charge.Audit();
                this.NextAudit();
            }
        }
    }
}
