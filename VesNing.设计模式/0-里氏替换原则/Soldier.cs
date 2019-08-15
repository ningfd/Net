using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0_里氏替换原则
{
    class Soldier
    {
        private AbstractGun gun;
        public void SetGun(AbstractGun gun)
        {
            this.gun = gun;
        }
        public void KillEnemy()
        {
            Console.WriteLine("士兵开始杀敌人..");
            gun.Shoot();
        }
    }
}
