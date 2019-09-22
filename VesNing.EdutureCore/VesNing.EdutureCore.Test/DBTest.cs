using VesNing.EdutureCore.Model;
using System;
using System.Collections.Generic;
using System.Text;
using VesNing.EdutureCore.MiniORM;
using System.Linq;
using VesNing.EdutureCore.Util;

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
            _ = entityMappingInfo.ToTable("TUser").Property(u => u.GetEntityProperty(c => c.Uid).ToCloumn("id")).
            Property(u => u.GetEntityProperty(c => c.UName).ToCloumn("Name"));
            Console.WriteLine(entityMappingInfo.ToString());

            EntityMappingInfo<Menu> entityMappingInfo1 = new EntityMappingInfo<Menu>();
            _ = entityMappingInfo1.ToTable("TMenu").Property(u => u.GetEntityProperty(c => c.Mid).ToCloumn("id")).
            Property(u => u.GetEntityProperty(c => c.MName).ToCloumn("Name"));
            Console.WriteLine(entityMappingInfo1.ToString());

            Console.WriteLine("**********************************************************");
           string connectionSql= JsonConifgUtil.Currnet.AddFile("system", "appsettings.json").
                ReadConfig("system").
                GetValue("ConnectionSql");

            DBManager manager = new DBManager(connectionSql);
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
            //manager.Entity<User>().Insert(use);
            //manager.Entity<Menu>().Insert(menu);

            //string sql=manager.Entity<User>().Query(u=>u.Uid==10&&u.UName=="张三");
            // Console.WriteLine(sql);

            manager.Set<UserInfo>();
            //manager.Entity<UserInfo>().Insert(new UserInfo
            //{
            //    UId = Guid.NewGuid().ToString(),
            //    UName="宁凡栋",
            //    UAccount="003185"
            //});
            //manager.Entity<UserInfo>().Insert(new UserInfo
            //{
            //    UId = Guid.NewGuid().ToString(),
            //    UName = "宁俊哲",
            //    UAccount = "003186"
            //});
            List<UserInfo> users=manager.Entity<UserInfo>().Query(u=>u.UName=="宁凡栋"||u.UName=="宁俊哲");
            users.ForEach(user=> 
            {
                Console.WriteLine(user.ToString()+"==============>"+user.UId);
            });
            Console.Read();

        }
    }
}
