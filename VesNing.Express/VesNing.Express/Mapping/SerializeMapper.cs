using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VesNing.Express.Mapping
{
    class SerializeMapper
    {
        public static PeopleCopy Mapper(People p)
        {
            return JsonConvert.DeserializeObject<PeopleCopy>(JsonConvert.SerializeObject(p));
        }
    }
}
