using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0_里氏替换原则
{
   public abstract class AbstractGun
    {
        public abstract void Shoot();
    }

    public class HandGun : AbstractGun
    {
        public override void Shoot()
        {
            Console.WriteLine("手枪射击。。。。");
        }
    }
    public class Rifle : AbstractGun
    {
        public override void Shoot()
        {
            Console.WriteLine("步枪射击。。。。");
        }
    }
    public class MachineGun : AbstractGun
    {
        public override void Shoot()
        {
            Console.WriteLine("机枪扫射。。。。");
        }
    }
}
