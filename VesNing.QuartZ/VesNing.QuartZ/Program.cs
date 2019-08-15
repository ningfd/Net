using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VesNing.QuartZ
{
    class Program
    {
        static void Main(string[] args)
        {
            QuaretZManager.Start().GetAwaiter().GetResult();
            Console.Read();
        }
    }
}
