using GameBlogSite.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameBlogSite.Controllers
{
    public class CategoryController : Controller
    {
        Context db = new Context();
        // GET: Category
        public ActionResult Index(int? id)
        {
            var categoryId = db.Category.Find(id);
            ViewBag.Category = categoryId.Name;
            ViewBag.Count = categoryId.Id;

            var category = db.Article.Where(x => x.CategoryId == id && x.Status == true).ToList();
            return View(category);
        }
    }
}