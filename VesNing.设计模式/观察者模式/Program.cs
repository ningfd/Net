using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 观察者模式
{
    /*业务场景：家里的猫叫了一声  ==》被观察者 进行发布
     * 老鼠跑了，
     * 小孩哭了，
     * 爸爸咆哮
     * 妈妈安抚，
     * 小偷藏起来。
     * 邻居开灯。
     * 
     * 
     * 
     **/
    class Program
    {
        /// <summary>
        /// 观察者模式：发布-订阅 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //上层进行功能交互
            //Program.Invoke2();
            Program.Invoke3();
            Console.Read();
        }


        /// <summary>
        ///  猫叫一声之后，随后发生一系列事情。
        ///  问题来了：这样调用的话，会导致Cat类与其他类的耦合度非常强，
        ///  并且在开发时需要考虑开闭原则、最少知道原则，这时mouse、father等就不适合放在这
        ///  可能有人会疑问，为什么不能放到上层？是这样的：如果放到上层的话 对于封装就没什么意义了，
        ///  因为猫叫了，后期发生的一系列事件是属于Cat的职责，同时如果都放到上层的话，试想一下，
        ///  winform中如果涉及到事件的操作全都放到上层。。这肯定不现实的。
        /// </summary>
        public static void Invoke1()
        {
            new Cat().Miao1();
        }
        /// <summary>
        /// 将cat叫之后需要处理的动作在此进行配置
        /// 这种绑定Action对外调用不宜用，如果后期他们传递参数的话就会报错，
        /// 所以需要约束他们的行为，这时候可以声明一个接口IObserver
        /// </summary>
        public static void Invoke2()
        {
            Cat cat = new Cat();
            cat.Register(new Mouse().Run);
            cat.Register(new Father().Rore);
            cat.Register(new Mother().Placate);
            cat.Register(new Thief().Hide);
            cat.Register(new Neighbor().Light);
            cat.Miao2();
        }
        /// <summary>
        /// 声明一个接口IObserver
        /// </summary>
        public static void Invoke3()
        {
            Cat cat = new Cat();
            cat.Register(new Mouse());
            cat.Register(new Father());
            cat.Register(new Mother());
            cat.Register(new Thief());
            cat.Register(new Neighbor());
            cat.Miao3();
        }
        /// <summary>
        /// C#实现
        /// </summary>
        public static void Invoke4()
        {
            Cat cat = new Cat();
            cat.CatEvent+=new Mouse().Run;
            cat.CatEvent += new Father().Rore;
            cat.CatEvent += new Mother().Placate;
            cat.CatEvent += new Thief().Hide;
            cat.CatEvent += new Neighbor().Light;
            cat.Miao4();
        }
    }
}
