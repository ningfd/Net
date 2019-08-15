using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VesNing.Model.Blog
{
    /// <summary>
    /// 文章类别
    /// </summary>
   public class Category
    {
        /// <summary>
        /// 类别Id
        /// </summary>
        public int  Id
        {
            get;set;
        }
        /// <summary>
        /// 类别标题
        /// </summary>
        public string Catption
        {
            get;set;
        }

    }
}
