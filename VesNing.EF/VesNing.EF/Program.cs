using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using VesNing.Bussiness.Interface;
using VesNing.EF.Util;
using VesNing.Model;

namespace VesNing.EF
{
    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer unityContainer = UntityContain.GetContainer();
            using (IUserRoleMenuService userRoleMenuService = unityContainer.Resolve<IUserRoleMenuService>())
            {
                Console.WriteLine("增用户&角色 (随机测试10个用户，5个角色)");
                userRoleMenuService.AddUserRole();
            }
            Console.Read();

        }
    }
}
