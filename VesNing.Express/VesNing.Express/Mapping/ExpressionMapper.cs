using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace VesNing.Express.Mapping
{
    class ExpressionMapper
    {
       private static Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
        public static Tout Mapper<Tin, Tout>(Tin tin)
        {
            string key = $"func_{tin.GetType().FullName}_{typeof(Tout).GetType().FullName}";
            if (!keyValuePairs.Keys.Contains(key))
            {
                var parameter = Expression.Parameter(typeof(Tin), "p");
                List<MemberBinding> memberBindingList = new List<MemberBinding>();
                foreach (var item in typeof(Tout).GetProperties())
                {
                    MemberExpression memberExpression = Expression.Property(parameter, tin.GetType().GetProperty(item.Name));
                    MemberBinding memberBinding = Expression.Bind(item, memberExpression);
                    memberBindingList.Add(memberBinding);
                }
                foreach (var item in typeof(Tout).GetFields())
                {
                    MemberExpression memberExpression = Expression.Field(parameter, tin.GetType().GetField(item.Name));
                    MemberBinding memberBinding = Expression.Bind(item, memberExpression);
                    memberBindingList.Add(memberBinding);
                }
                MemberInitExpression memberInitExpression = Expression.MemberInit(Expression.New(typeof(Tout)), memberBindingList.ToArray());
                var lambda = Expression.Lambda<Func<Tin, Tout>>(memberInitExpression, new ParameterExpression[] { parameter });
                Console.WriteLine(lambda.ToString());
                Func<Tin, Tout> func = lambda.Compile();
                keyValuePairs.Add(key,func);
            }
            return ((Func < Tin, Tout >)( keyValuePairs[key])).Invoke(tin);
        }
    }
}
