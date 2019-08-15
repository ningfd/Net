using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VesNing.Express.Mapping
{
    /// <summary>
    /// 硬编码映射
    /// </summary>
    class HardCodingMapper
    {
        public static PeopleCopy Mapper(People p) {

            PeopleCopy copy = new PeopleCopy()
            {
                Id = p.Id,
                Name = p.Name,
                Number = p.Number,
                Age = p.Age
            };
            return copy;
        }
    }
}
