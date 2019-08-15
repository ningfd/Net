using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VesNing.Bussiness.Interface;
using VesNing.Model;

namespace VesNing.Bussiness.Service
{
    public class UserRoleMenuService:BaseService, IUserRoleMenuService
    {
        #region 构造函数
        public UserRoleMenuService(DbContext dbContext) : base(dbContext)
        {

        }
        #endregion

        #region a 增用户&角色 (随机测试10个用户，5个角色)
        public void AddUserRole()
        {
            List<SysUser> userList = new List<SysUser>() {
                new SysUser(){
                    Name="Ves0",
                    Password="123",
                    Status=0,
                    Phone="1111111112222",
                    Mobile="543276543876543",
                    Address="那个穷旮沓",
                    CreateTime=DateTime.Now
                },
                 new SysUser(){
                    Name="Ves1",
                    Password="123",
                    Status=0,
                    Phone="1111111112222",
                    Mobile="543276543876543",
                    Address="那个穷旮沓",
                    CreateTime=DateTime.Now
                },
                  new SysUser(){
                    Name="Ves2",
                    Password="123",
                    Status=0,
                    Phone="1111111112222",
                    Mobile="543276543876543",
                    Address="那个穷旮沓",
                    CreateTime=DateTime.Now
                },
                   new SysUser(){
                    Name="Ves3",
                    Password="123",
                    Status=0,
                    Phone="1111111112222",
                    Mobile="543276543876543",
                    Address="那个穷旮沓",
                    CreateTime=DateTime.Now
                },
                    new SysUser(){
                    Name="Ves4",
                    Password="123",
                    Status=0,
                    Phone="1111111112222",
                    Mobile="543276543876543",
                    Address="那个穷旮沓",
                    CreateTime=DateTime.Now
                },
                     new SysUser(){
                    Name="Ves5",
                    Password="123",
                    Status=0,
                    Phone="1111111112222",
                    Mobile="543276543876543",
                    Address="那个穷旮沓",
                    CreateTime=DateTime.Now
                },
                      new SysUser(){
                    Name="Ves6",
                    Password="123",
                    Status=0,
                    Phone="1111111112222",
                    Mobile="543276543876543",
                    Address="那个穷旮沓",
                    CreateTime=DateTime.Now
                },
                       new SysUser(){
                    Name="Ves7",
                    Password="123",
                    Status=0,
                    Phone="1111111112222",
                    Mobile="543276543876543",
                    Address="那个穷旮沓",
                    CreateTime=DateTime.Now
                },
                        new SysUser(){
                    Name="Ves8",
                    Password="123",
                    Status=0,
                    Phone="1111111112222",
                    Mobile="543276543876543",
                    Address="那个穷旮沓",
                    CreateTime=DateTime.Now
                },
                         new SysUser(){
                    Name="Ves9",
                    Password="123",
                    Status=0,
                    Phone="1111111112222",
                    Mobile="543276543876543",
                    Address="那个穷旮沓",
                    CreateTime=DateTime.Now
                }
            };
            this.Insert<SysUser>(userList);
            List<SysRole> roles = new List<SysRole>() {
                new SysRole(){Text="董事长",Description="董事长",Status=0,CreateTime=DateTime.Now },
                new SysRole(){Text="总经理",Description="总经理",Status=0,CreateTime=DateTime.Now },
                new SysRole(){Text="部门经理",Description="部门经理",Status=0,CreateTime=DateTime.Now },
                new SysRole(){Text="开发经理",Description="开发经理",Status=0,CreateTime=DateTime.Now },
                new SysRole(){Text="架构师",Description="架构师",Status=0,CreateTime=DateTime.Now }
            };
            this.Insert<SysRole>(roles);
        }
        #endregion

        #region   b 增菜单 (随机测试10个菜单，要求起码三层父子关系id/parentid，SourcePath=父SourcePath+/+GUID)
        public void AddMenu()
        {
            //List<SysMenu> menus = new List<SysMenu>();
            ////寻找三层的菜单
            //var root = this.Query();
            //第一层菜单
            List<SysMenu> firstMenu = new List<SysMenu>() {
                new SysMenu(){ ParentId=-1,Text="自定义菜单",},
            };
        }

        #endregion

    }
}
