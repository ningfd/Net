using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VesNing.MVC5.Filter
{
    public class CustomerFilter : FilterAttribute
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write($"{this.GetType().FullName}的方法执行前");
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Write($"{this.GetType().FullName}的方法执行后");
        }
    }
}