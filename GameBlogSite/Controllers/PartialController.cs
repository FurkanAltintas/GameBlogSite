using GameBlogSite.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameBlogSite.Controllers
{
    public class PartialController : Controller
    {
        Context db = new Context();
        // GET: Partial
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Category()
        {
            var category = db.Category.Where(x => x.Status == true).ToList();
            return View(category);
        }

        public ActionResult LatestPost()
        {
            var article = db.Article.OrderByDescending(x => x.Id).Take(5).ToList();
            return View(article);
        }

        public ActionResult AboutUs()
        {
            var writer = db.Writer.ToList();
            return View(writer);
        }

        public ActionResult Slider()
        {
            var slider = db.Slider.ToList();
            return View(slider);
        }

        public ActionResult Instagram()
        {
            var instagram = db.Footer.ToList();
            return View(instagram);
        }

        public ActionResult PopularTags()
        {
            var tags = db.Category.ToList();
            return View(tags);
        }

        [HttpGet]
        public ActionResult Archives()
        {
            var article = db.Article.ToList();
            return View(article);
        }

        [HttpPost]
        public ActionResult Archives(int id)
        {
            var date = db.Article.Find();
            var article = db.Article.Where(x => x.Id == date.Id).ToList();
            return View(article);
        }

        public ActionResult Categories()
        {
            var categories = db.Category.ToList();
            return View(categories);
        }

        public ActionResult Article()
        {
            var article = db.Article.OrderByDescending(x => x.Id).ToList();
            return View(article);
        }

        public ActionResult MostRead()
        {
            var article = db.Article.Take(2).OrderByDescending(x => x.ReadingCount).ToList();
            return View(article);
        }

        [HttpGet]
        public ActionResult LeaveaComment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LeaveaComment(int id, Comment comment)
        {
            var articleComment = db.Article.Find(id);

            if (ModelState.IsValid)
            {
                comment.ArticleId = articleComment.Id;
                comment.Date = DateTime.Now;
                db.Comment.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(comment);
            }
        }

        [HttpGet]
        public ActionResult Reply()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Reply(int id, Reply reply)
        {
            var articleComment = db.Comment.Find(id);

            if (ModelState.IsValid)
            {
                reply.CommentId = id;
                reply.Status = true;
                db.Reply.Add(reply);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(reply);
            }
        }
    }
}