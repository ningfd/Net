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
    internal class ArticleService : BlogBaseService, IArticleService
    {
        public ArticleService() : base(BlogDataKind.Article)
        {

        }

        public void AddArticle(Article article)
        {
            base.Insert<Article>(article);
        }
        public IEnumerable<Article> QueryArticleAll()
        {
           return base.QueryAll<Article>().AsEnumerable<Article>();
        }
        public IEnumerable<Article> QueryArticle(Expression<Func<Article,bool>> whereFunc)
        {
            return base.Query<Article>(whereFunc);
        }
    }
}
