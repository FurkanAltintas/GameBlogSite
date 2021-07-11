using GameBlogSite.Models;
using GameBlogSite.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameBlogSite.Controllers
{
    public class ArticleController : Controller
    {
        Context db = new Context();
        ArticleComments ac = new ArticleComments();
        // GET: Article
        public ActionResult Index(int? id)
        {
            Startup r = new Startup();

            Comment c = new Comment();

            if (id == null)
            {

            }

            var article = db.Article.Find(id);

            if (article == null)
            {

            }

            ac.Article = db.Article.Where(x => x.Id == id && x.Status == true).ToList();
            ac.Comment = db.Comment.Where(x => x.ArticleId == id && x.Status == true).ToList();

            foreach (var item in ac.Comment)
            {
                ac.Reply = db.Reply.Where(x => x.CommentId == item.Id).ToList();
            }

            ac.Category = db.Category.Where(x => x.Status == true).ToList();
            ac.Tag = db.Tag.Where(x => x.ArticleId == id && x.Status == true).ToList();
            ac.Images = db.Images.Where(x => x.ArticleId == id).Take(2).ToList();
            article.ReadingCount++;
            db.SaveChanges();

            ViewBag.Title = article.Title;

            return View(ac);
        }
    }
}