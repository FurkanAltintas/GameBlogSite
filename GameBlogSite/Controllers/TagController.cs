using GameBlogSite.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GameBlogSite.Controllers
{
    public class TagController : Controller
    {
        Context db = new Context();
        // GET: Tag
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var tag = db.Tag.Find(id);

            if (tag == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var tagList = db.Article.Where(x => x.Id == tag.ArticleId).ToList();
            return View(tag);
        }
    }
}