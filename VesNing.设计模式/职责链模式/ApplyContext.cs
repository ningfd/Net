using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 职责链模式
{
    /// <summary>
    /// 上下文信息
    /// </summary>
     class ApplyContext
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Caption { get; set; }
        public int ApplyDay { get; set; }
        public string Note { get; set; }
        public override string ToString()
        {
            string msg=$"请假条-{this.Caption}\r\n编号：{this.Id } 姓名：{this.Name} \r\n请假时长：{ApplyDay}\r\n{Note}";
            return msg;
        }
    }
}
