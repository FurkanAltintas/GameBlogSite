using GameBlogSite.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameBlogSite.Controllers
{
    public class HomeController : Controller
    {
        Context db = new Context();
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Description = "Oyun haberleri paylaşan minik bir blog sitesi.";
            ViewBag.Keywords = "Oyun, Bilgisayar, Telefon, Moba, RogueLike, Aksiyon, Macera, Online";

            var blog = db.Article.ToList();
            return View(blog);
        }
    }
}