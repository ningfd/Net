using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VesNing.Bussiness.Interface;
using VesNing.Infrastructure;
using VesNing.Model.Blog;

namespace VesNing.Bussiness.Service
{
    public class BlogBaseService: IBlogBaseService
    {
        private BlogDataKind kind;
        public BlogBaseService(BlogDataKind kind)
        {
            this.kind = kind;
        }
        public void Insert<T>(T t) where T:class
        {
            BogDataFactory<T>.Instance[kind].Add(t);
        }

        public IQueryable<T> Query<T>(Expression<Func<T, bool>> whereFunc) where T : class
        {
            IList<T> list = BogDataFactory<T>.Instance[kind];
            return list.AsQueryable<T>().Where<T>(whereFunc);
        }

        public IQueryable<T> QueryAll<T>() where T : class
        {
            IList<T> list = BogDataFactory<T>.Instance[kind];
            return list.AsQueryable<T>();
        }
    }
}
