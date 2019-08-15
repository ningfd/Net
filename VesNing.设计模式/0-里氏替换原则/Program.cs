using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0_里氏替换原则
{
    class Program
    {
        static void Main(string[] args)
        {
            Program.Invoke2();
            Console.ReadLine();
        }
        public static void Invoke1()
        {
            Soldier sanmao = new Soldier();
            sanmao.SetGun(new HandGun());
            sanmao.KillEnemy();
        }
        public static void Invoke2()
        {
            Father person = new Father();
            person.DoSomthing(new Axe());

            Son son = new Son();
            son.DoSomthing(new Axe());
            son.DoSomthing(new object());
        }
    }
}
