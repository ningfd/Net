using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VesNing.Model.Blog
{
   public class Article
    {
        /// <summary>
        /// 文章Id
        /// </summary>
        public int Id
        {
            get;set;
        }
        /// <summary>
        /// 文章分类
        /// </summary>
        public int CategoryId
        {
            get;set;
        }
        public Category Category
        {
            get;set;
        }

        /// <summary>
        /// 作者
        /// </summary>
        public string Author
        {
            get;set;
        }
        /// <summary>
        /// 文章标题
        /// </summary>
        public string Caption
        {
            get;set;
        }

        /// <summary>
        /// 文章内容
        /// </summary>
        public string Content
        {
            get;set;
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime
        {
            get;set;
        }

    }
}
