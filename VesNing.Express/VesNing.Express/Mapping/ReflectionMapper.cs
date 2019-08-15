using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VesNing.Express.Mapping
{
    /// <summary>
    /// 进行反射进行匹配
    /// </summary>
    class ReflectionMapper
    {
        public  static Tout Mapper<Tin, Tout>(Tin inEntity) where Tin:class
                                                    where Tout:class
                                                         
        {
            Tout outEntity  = Activator.CreateInstance<Tout>(); 
            Type outEntityType = outEntity.GetType();
            
            PropertyInfo[] outEtyProp=outEntityType.GetProperties();
            foreach (PropertyInfo info in outEtyProp)
            {
                info.SetValue(outEntity,inEntity.GetType().GetProperty(info.Name).GetValue(inEntity));
            }
            foreach (FieldInfo info in outEntityType.GetFields())
            {
                info.SetValue(outEntity, inEntity.GetType().GetField(info.Name).GetValue(inEntity));
            }
            return outEntity;
        }
    }
}
