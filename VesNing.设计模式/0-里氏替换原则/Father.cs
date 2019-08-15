using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0_里氏替换原则
{
    class Father
    {
        public void DoSomthing(Axe val)
        {
            Console.WriteLine("Father do something.."+val.ToString() );
            
        }

    }
    class Son:Father
    {
        public void DoSomthing(Object val)
        {
            Console.WriteLine("Son do Something.."+val.ToString());
        }
    }
    class Axe
    {
        public void Cut()
        {
            Console.WriteLine("Axe is Cutting..");
        }
    }
}
