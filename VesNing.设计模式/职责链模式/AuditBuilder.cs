using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 装饰模式;

namespace 职责链模式
{
    class AuditBuilder
    {
        /// <summary>
        /// 反射+配置文件
        /// </summary>
        /// <returns></returns>
        public static AbstractAudit Builder(ApplyContext context)
        {
            AbstractAudit dev = new DevManagerAudit(context) { ID = "01", Name = "开发经理王" };
            AbstractAudit charge = new ChargeAudit(context) { ID = "02", Name = "主管李" };
            AbstractAudit dep = new DepManagerAudit(context) { ID = "03", Name = "部门经理赵" };
            AbstractAudit major = new MajordomoAudit(context) { ID = "04", Name = "总监孙" };
            AbstractAudit ceo = new CEOAudit(context) { ID = "05", Name = "CEO" };
            dev.SetNextAudit(charge);
            charge.SetNextAudit(dep);
            dep.SetNextAudit(major);
            return dev;
        }
    }
}
