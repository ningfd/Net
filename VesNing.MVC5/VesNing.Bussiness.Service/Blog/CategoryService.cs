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
    class CategoryService :  BlogBaseService, ICategoryService
    {
        public CategoryService() : base(BlogDataKind.Category)
        {

        }

        public void AddCategory(Category category)
        {
            base.Insert<Category>(category);
        }
        public IEnumerable<Category> QueryCategoryAll()
        {
            return base.QueryAll<Category>().AsEnumerable<Category>();
        }
        public IEnumerable<Category> QueryCategory(Expression<Func<Category, bool>> whereFunc)
        {
            return base.Query<Category>(whereFunc);
        }
    }
}