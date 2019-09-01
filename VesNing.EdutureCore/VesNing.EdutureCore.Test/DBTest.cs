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
    class DBTest
    {
        static void Main(string[] args)
        {
            EntityMappingInfo<User> entityMappingInfo = new EntityMappingInfo<User>();
            _ = entityMappingInfo.ToTable("TUser").Property(u => u.GetEntityFiled(c => c.Uid).ToCloumn("id")).
            Property(u => u.GetEntityFiled(c => c.UName).ToCloumn("Name"));
            Console.WriteLine(entityMappingInfo.ToString());

            EntityMappingInfo<Menu> entityMappingInfo1 = new EntityMappingInfo<Menu>();
            _ = entityMappingInfo1.ToTable("TMenu").Property(u => u.GetEntityFiled(c => c.Mid).ToCloumn("id")).
            Property(u => u.GetEntityFiled(c => c.MName).ToCloumn("Name"));
            Console.WriteLine(entityMappingInfo1.ToString());

            Console.WriteLine("**********************************************************");
            DBManager manager = new DBManager("");
            manager.OnModelBuilder<User>(entityMappingInfo);
            manager.OnModelBuilder<Menu>(entityMappingInfo1);
            User use = new User()
            {
                Uid = 010,
                UName = "宁凡栋",
                UCode = "03815",
                UAge = 28
            };
            Menu menu = new Menu()
            {
                Mid = 10,
                MName = "我是菜单"
            };
            manager.Entity<User>().Insert(use);
            manager.Entity<Menu>().Insert(menu);
            Console.Read();

        }
    }
}
