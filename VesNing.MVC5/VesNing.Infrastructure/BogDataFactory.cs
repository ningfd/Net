using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VesNing.Model.Blog;

namespace VesNing.Infrastructure
{
    /// <summary>
    /// 单例模式
    /// 博客的数据工厂
    /// </summary>
    public class BogDataFactory<T> where T : class
    {
        //缓存字典
        private static IDictionary<Enum, IEnumerable<object>> cacheDict = null;
        private static IEnumerable<Article> _ArticleList = null;
        private static IEnumerable<Category> _CategoryList = null;
        private static BogDataFactory<T> obj = new BogDataFactory<T>();
        private BogDataFactory()
        {
            cacheDict = new Dictionary<Enum, IEnumerable<object>>();
            _ArticleList = new List<Article>();
            _CategoryList = new List<Category>();
            cacheDict.Add(BlogDataKind.Category, _CategoryList);
            cacheDict.Add(BlogDataKind.Article, _ArticleList);
            this.InitData();

        }

        public static BogDataFactory<T> Instance
        {
            get
            {
                return obj;
            }
        }


        public List<T> this[Enum index]
        {
            get
            {
                return cacheDict[index] as List<T>;
            }
        }
        private void InitData()
        {
            var _category = new Category()
            {
                Id = 1,
                Catption = "问题困惑"
            };
            List<Category> _categoryList = _CategoryList as List<Category>; //this[BlogDataKind.Category] as List<Category>; //_CategoryList as List<Category>;
            _categoryList.Add(_category);

            List<Article> _articleList = _ArticleList as List<Article>; //this[BlogDataKind.Article] as List<Article>;  //_ArticleList as List<Article>;
            _articleList.Add(new Article()
            {
                Id = 1,
                CategoryId = 1,
                Category = _category,
                Caption = "单例模式在多线程下如何保证数据安全",
                Content = "单例模式因为全局唯一，只存在一个实例对象。这样的话如果存在多个同时访问的话，怎么保证数据的安全？"
            });
            _articleList.Add(new Article()
            {
                Id = 2,
                CategoryId = 1,
                Category = _category,
                Caption = "泛型类的子类可以具体指明类操作吗，或者泛型类继承的意义？",
                Content = @"如果父类作为泛型类，指定一些公共方法，后期子类指定具体类，进行特殊类型操作，是否可以，
                           或者说是否父类的泛型类作为公共方法更好"
            });
            _articleList.Add(new Article()
            {
                Id = 2,
                CategoryId = 1,
                Category = _category,
                Caption = "静态方法的使用时机",
                Content = @"静态方法的使用时机，静态变量、静态类、静态方法是不是越多越好"
            });
            _articleList.Add(new Article()
            {
                Id = 2,
                CategoryId = 1,
                Category = _category,
                Caption = "静态变量和单例模式",
                Content = @"静态变量和单例模式的区别，单例模式是否可以当做缓存使用？"
            });
        }
    }
    public enum BlogDataKind
    {
        Category,
        Article
    }

}

