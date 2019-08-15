using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VesNing.Bussiness.Service.Blog;
using VesNing.Model.Blog;

namespace VesNing.MVC5.Controllers
{
    public class HomeController : Controller
    {
        private BlogServiceFactory blogServiceFactory = BlogServiceFactory.Instance;
        public ActionResult Index()
        {
           IEnumerable<Article> list=blogServiceFactory.ArticleService.QueryArticleAll();
            return View(list);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}