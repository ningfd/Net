using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 单例模式
{
    /// <summary>
    /// 定义一个场景：
    /// 古代大臣们需要向皇帝汇报工作
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //一品大员
            Minister primeMinister = new Minister("宰相","一品大员","黄河发大水。。");
            primeMinister.Talk();
            Minister general = new Minister("大将军","三品大员","阻击蒙古族人。。");
            general.Talk();
            Console.ReadLine();
        }
    }
}
