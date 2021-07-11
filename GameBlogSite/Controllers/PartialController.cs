using GameBlogSite.Models;
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
        ArticleComments ac = new ArticleComments();
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
            var writer = db.Writer.Take(1).ToList();
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

        public ActionResult PopularCategorys()
        {
            Article a = new Article();
            var category = db.Category.OrderByDescending(x => x.Id == a.CategoryId).ToList();
            //var category = db.Category.ToList();
            return View(category);
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

        public ActionResult TagList(int id, Tag tag)
        {
            var tagList = db.Tag.Where(x => x.ArticleId == id && x.Status == true).ToList();
            return View(tagList);
        }

        public ActionResult ImageList(int id, Images ımages)
        {
            var imageList = db.Images.Where(x => x.ArticleId == id).ToList();
            return View(imageList);
        }

        public ActionResult RecentComments()
        {
            var comments = db.Comment.Where(x => x.Status == false).OrderByDescending(x => x.Id).Take(4).ToList();
            return View(comments);
        }

        public ActionResult NewArticle()
        {
            var article = db.Article.Where(x => x.IsActive == false && x.Status == true).OrderByDescending(x => x.Id).Take(4).ToList();
            return View(article);
        }

        [HttpGet]
        public ActionResult Comment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Comment(int id, Reply reply)
        {
            var email = (string)Session["email"];
            var uye = db.Writer.FirstOrDefault(x => x.Email == email);

            var key = db.Comment.Find(id);

            reply.CommentId = id;
            reply.NameSurName = Session["user"].ToString();
            reply.Email = email;
            reply.Date = DateTime.Now;
            reply.Status = true;
            db.Reply.Add(reply);
            db.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        public ActionResult SkillSet(int id)
        {
            var key = db.Skill.Where(x => x.WriterId == id).ToList();
            return View(key);
        }

        public ActionResult Activity(int id)
        {
            ac.Comment = db.Comment.Take(3).OrderByDescending(x => x.Id).Where(x => x.Article.WriterId == id).ToList();

            ac.Images = db.Images.OrderByDescending(x => x.Id).Where(x => x.Article.WriterId == id).ToList();

            return View(ac);
        }

        [HttpGet]
        public ActionResult WriterDetail(int? id)
        {
            if (id == null)
            {

            }

            var key = db.Writer.Find(id);

            if (key == null)
            {

            }
            return View(key);
        }

        [HttpPost]
        public ActionResult WriterDetail(int id, Writer writer)
        {

            return RedirectToAction("WriterDetail", "Admin");
        }






        //public ActionResult Search(string search)
        //{
        //var info = from x in db.Article select x;
        //if (!string.IsNullOrEmpty(search))
        //{
        //    info = info.Where(x => x.Title.Contains(search));
        //}
        //return View(info.ToList());
        //return View();
        //}
    }
}