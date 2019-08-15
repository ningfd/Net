using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VesNing.Express
{
    class PeopleCopy
    {
        public int Id;
        public string Name { get; set; }
        public int Age { get; set; }
        public int Number { get; set; }

        public override string ToString()
        {
            string s = $"Id:{Id} Name:{Name} Age:{Age} Number:{Number}";
            Console.WriteLine(s);
            return s;
        }
    }
}
