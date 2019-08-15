using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VesNing.Express
{
    class Program
    {
        static void Main(string[] args)
        {
            ExpressDeal.MontageBinaryExpress();
            Console.WriteLine("**********************************");
            ExpressDeal.MontageEntityPropertyExpress();
            Console.WriteLine("***********实体类转换***************");
            ExpressDeal.MapperCompare();
            Console.Read();
        }
    }
}
