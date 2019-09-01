using VesNing.EdutureCore.Model;
using System;
using System.Collections.Generic;
using System.Text;
using VesNing.EdutureCore.MiniORM;
using System.Linq;

namespace VesNing.EdutureCore.Test
{
    /// <summary>
    /// 数值与数据库字段映射
    /// </summary>
    class EntityFiledMappingTest
    {
        static void Main(string[] args)
        {
            EntityMappingInfo<User> entityMappingInfo = new EntityMappingInfo<User>();
            _ = entityMappingInfo.ToTable("TUser").Property(u => u.GetEntityFiled(c => c.Uid).ToCloumn("id")).
            Property(u => u.GetEntityFiled(c => c.UName).ToCloumn("Name"));
            Console.WriteLine(entityMappingInfo.ToString());
            Console.Read();
            IQueryable
        }
    }
}
