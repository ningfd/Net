using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 装饰模式;

namespace 职责链模式
{
    class Program
    {
        static void Main(string[] args)
        {
            //职责链模式
            //业务场景：小明回家结婚，需要请假15天，现需要领导审批
            //          审批人：开发经理-部门主管-部门经理-总监-CEO
            //          开发经理：2天的审批权限
            //          部门主管：5天的审批权限
            //          部门经理：10天的审批权限
            //          总监：15天的审批权限
            //          CEO:15天以上
            ApplyContext context = new ApplyContext()
            {
                Id = "0909",
                Name = "小明",
                Caption = "婚假",
                ApplyDay=15,
                Note="我于10.01在老家结婚，请领导批准！"
            };
            Console.WriteLine(context.ToString());
            Console.WriteLine("****************提交审批*******************");
            Program.Invoke4(context);
            Console.ReadLine();
        }
        /// <summary>
        /// 初级
        /// 面向过程编码，代码不可复用，节点不可自动增加，顺序绑死
        /// </summary>
        private static void Invoke1(ApplyContext context)
        {
            
            if (context.ApplyDay<=2)
            {
                Console.WriteLine("项目经理审批：通过");
            }
            else if (context.ApplyDay<=5)
            {
                Console.WriteLine("部门主管审批：通过");
            }
            else if (context.ApplyDay <= 10)
            {
                Console.WriteLine("部门经理审批：通过");
            }
            else if (context.ApplyDay <= 15)
            {
                Console.WriteLine("总监审批：通过");
            }
            else
            {
                Console.WriteLine("CEO审批：通过");
            }

        }
        /// <summary>
        /// 中级开发
        /// 面向对象编程
        /// 流程固化 中间节点发生变化 影响大
        /// </summary>
        /// <param name="context"></param>
        private static void Invoke2(ApplyContext context)
        {
            AbstractAudit audit = new DevManagerAudit(context) { ID = "01", Name = "开发经理王" };
            audit.Audit();
        }
        /// <summary>
        /// 高级开发
        /// 流程可随意调整
        /// </summary>
        /// <param name="context"></param>
        private static void Invoke3(ApplyContext context)
        {
            AbstractAudit dev=new DevManagerAudit(context) { ID = "01", Name = "开发经理王" };
            AbstractAudit charge = new ChargeAudit(context) { ID = "02", Name = "主管李" };
            AbstractAudit dep = new DepManagerAudit(context) { ID = "03", Name = "部门经理赵" };
            AbstractAudit major = new MajordomoAudit(context) { ID = "04", Name = "总监孙" };
            AbstractAudit ceo = new CEOAudit(context) { ID = "05", Name = "CEO" };
            dev.SetNextAudit(charge);
            charge.SetNextAudit(dep);
            dep.SetNextAudit(major);
            ceo.SetNextAudit(ceo);
            dev.Audit();
        }
        /// <summary>
        /// 反射+配置文件自动获取审批节点
        /// </summary>
        /// <param name="context"></param>
        public static void Invoke4(ApplyContext context)
        {
            AbstractAudit dev=AuditBuilder.Builder(context);
            dev.Audit();
        }
    }
}
