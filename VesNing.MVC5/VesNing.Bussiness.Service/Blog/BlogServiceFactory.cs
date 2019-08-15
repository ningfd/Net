using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VesNing.Bussiness.Interface;

namespace VesNing.Bussiness.Service.Blog
{

    /// <summary>
    /// 类工厂
    /// 使用组合的模式最好，这个地方可能使用的不正确
    ///
    /// </summary>
    public class BlogServiceFactory
    {
        private static readonly BlogServiceFactory obj = new BlogServiceFactory();
        private BlogServiceFactory()
        {
           
        }
        public static BlogServiceFactory Instance
        {
            get
            {
                return obj;
            }
        }

        /// <summary>
        /// 这里是定义成单例好，还是自由形成对象？
        /// </summary>
        public IArticleService ArticleService
        {
            get
            {
                return new ArticleService();
            }
        }
        public ICategoryService CategoryService
        {
            get
            {
                return new CategoryService();
            }
        }
    }
}
