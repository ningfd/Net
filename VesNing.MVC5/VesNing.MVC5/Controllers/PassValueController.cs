using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VesNing.MVC5.Controllers
{
    public class PassValueController : Controller
    {
        // GET: PassValue
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ValueTest()
        {
            //1.viewBag传值，ViewBag是Dynamic类型，是个弱类型，在运行时解析，作用域在一个请求之内
            ViewBag.ViewBagView = "这是ViewBag";
            //2.viewData传值，作用域在一个请求之内
            ViewData["ViewDataView"] = "这是ViewData";
            //3.tempData传值，作用域在一个session中
            TempData["TempData"] = "这是TempData";
            return View();
        }
    }
}