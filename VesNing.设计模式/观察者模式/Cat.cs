using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 观察者模式
{
    /// <summary>
    /// 定义猫的委托
    /// </summary>
    public delegate void CatHandler();
    class Cat
    {
        #region 1.耦合度高
        public void Miao1()
        {
            Console.WriteLine($"猫喵了一声。。。");
            /*
             猫叫一声之后，随后发生一系列事情。
             问题来了：这样调用的话，会导致Cat类与其他类的耦合度非常强，
             并且在开发时需要考虑开闭原则、最少知道原则，这时mouse、father等就不适合放在这
             可能有人会疑问，为什么不能放到上层？是这样的：如果放到上层的话 对于封装就没什么意义了，
             因为猫叫了，后期发生的一系列事件是属于Cat的职责，同时如果都放到上层的话，试想一下，
             winform中如果涉及到事件的操作全都放到上层。。这肯定不现实的。

            new Mouse().Run();
            new Father().Rore();
            new Mother().Placate();
            new Thief().Hide();
            new Neighbor().Light();
             */
        }

        #endregion

        #region 2.由上层进行配置
        private List<Action> actions = new List<Action>();

        public void Register(Action action)
        {
            actions.Add(action);
        }
        public void UnRegister(Action action)
        {
            if (this.actions.Contains(action))
            {
                actions.Remove(action);
            }
        }
        /// <summary>
        /// 猫喵了一声
        /// </summary>
        public void Miao2()
        {
            Console.WriteLine($"猫喵了一声。。。");
            /*
             通过上层自行配置
             */
            foreach (Action item in actions)
            {
                item();
            }
        }
        #endregion

        #region 3.有上层配置，约束调用的行为
        private List<IObserver> observers = new List<IObserver>();
        public void Register(IObserver observer)
        {
            observers.Add(observer);
        }
        public void UnRegister(IObserver observer)
        {
            if (this.observers.Contains(observer))
            {
                observers.Remove(observer);
            }
        }
        public void Miao3()
        {
            Console.WriteLine($"猫喵了一声。。。");
            /*
             通过上层自行配置
             */
            foreach (IObserver item in observers)
            {
                item.Handler();
            }
        }

        #endregion

        #region C#实现
        public event CatHandler CatEvent;
        public void Miao4()
        {
            Console.WriteLine($"猫喵了一声。。。");
            /*
             通过上层自行配置
             */
            if (CatEvent != null)
            {
                CatEvent();
            }
        }
        #endregion


    }
}
