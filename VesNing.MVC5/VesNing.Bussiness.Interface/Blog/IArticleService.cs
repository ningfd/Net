using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VesNing.Model.Blog;

namespace VesNing.Bussiness.Interface
{
   public interface IArticleService:IBlogBaseService
    {
        void AddArticle(Article article);
        IEnumerable<Article> QueryArticleAll();
        IEnumerable<Article> QueryArticle(Expression<Func<Article, bool>> whereFunc);

    }
}
