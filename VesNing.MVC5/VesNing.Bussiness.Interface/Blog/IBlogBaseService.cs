using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace VesNing.Bussiness.Interface
{
    public interface IBlogBaseService
    {
        void Insert<T>(T t) where T:class ;
        IQueryable<T> Query<T>(Expression<Func<T, bool>> whereFunc) where T : class;
        IQueryable<T> QueryAll<T>() where T : class;
    }
}
