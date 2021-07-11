using GameBlogSite.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameBlogSite.Utils
{
    public class BaseController : Controller
    {
        public Context db = new Context();
        public string user { get; set; }
        public string email { get; set; }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["email"] == null)
            {
                filterContext.Result = new RedirectResult("/Account/Login");
            }
            else
            {
                user = Session["user"].ToString();
                email = Session["email"].ToString();

            }
            base.OnActionExecuting(filterContext);
        }
    }
}