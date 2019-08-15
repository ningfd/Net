using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 职责链模式;

namespace 装饰模式
{
    abstract class AbstractAudit
    {
        protected ApplyContext Context;
        protected AbstractAudit NextAuditNode;
        public AbstractAudit(ApplyContext context)
        {
           // Console.WriteLine($"我是类:{ GetType().ToString()}");
            this.Context = context;
        }
        public string ID
        {
            get; set;
        }
        public string Name
        {
            get;set;
        }
        public virtual void Audit()
        {
            Console.WriteLine($"我是类:{ Name}");
        }
        public void SetNextAudit(AbstractAudit audit)
        {
            this.NextAuditNode = audit;
        }
        public void NextAudit()
        {
            if (this.NextAuditNode!=null)
            {
                this.NextAuditNode.Audit();
            }
        }
    }
}
