using GameBlogSite.Models;
using GameBlogSite.Models.EntityFramework;
using GameBlogSite.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameBlogSite.Controllers
{
    public class AdminController : BaseController
    {
        Context db = new Context();
        ArticleComments ac = new ArticleComments();
        WriterChatMessage wcm = new WriterChatMessage();
        // GET: Admin
        public ActionResult Index()
        {
            var category = db.Category.Where(x => x.Status == true).Count();
            ViewBag.Category = category;

            var writer = db.Writer.Count();
            ViewBag.Writer = writer;

            var article = db.Article.Count();
            ViewBag.Article = article;

            var reading = db.Article.Sum(x => x.ReadingCount / article);
            ViewBag.Reading = reading;

            return View();
        }

        #region Slider
        public ActionResult Slider()
        {
            var slider = db.Slider.ToList();
            return View(slider);
        }

        [HttpGet]
        public ActionResult SliderDetail(int? id)
        {
            if (id == null)
            {

            }

            var slider = db.Slider.Find(id);

            var article = ac.Article = db.Article.Where(x => x.Title == slider.Title).ToList();

            var articleKey = article.FirstOrDefault();

            var articleFind = db.Article.Find(articleKey.Id);

            ViewBag.nameSurname = articleFind.Writer.Name + " " + articleFind.Writer.SurName;

            ac.Images = db.Images.Where(x => x.ArticleId == articleFind.Id).ToList();

            ac.Slider = db.Slider.Where(x => x.Title == slider.Title).ToList();

            ac.Tag = db.Tag.Where(x => x.ArticleId == articleFind.Id).ToList();

            if (slider == null)
            {

            }

            return View(ac);
        }

        [HttpGet]
        public ActionResult SliderAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SliderAdd(Slider slider)
        {
            if (ModelState.IsValid)
            {
                db.Slider.Add(slider);
                db.SaveChanges();
                return RedirectToAction("Slider");
            }
            else
            {
                return View(slider);
            }
        }

        [HttpGet]
        public ActionResult SliderUpdate(int? id)
        {
            if (id == null)
            {

            }

            var slider = db.Slider.Find(id);

            if (slider == null)
            {

            }

            return View(slider);
        }

        [HttpPost]
        public ActionResult SliderUpdate(Slider slider, int id)
        {
            if (ModelState.IsValid)
            {
                var info = db.Slider.Find(id);
                info.Image = slider.Image;
                info.Title = slider.Title;
                info.Explanation = slider.Explanation;
                db.SaveChanges();
                return RedirectToAction("Slider");
            }
            else
            {
                return View(slider);
            }
        }

        [HttpGet]
        public ActionResult SliderDelete(int id)
        {
            var slider = db.Slider.Find(id);
            db.Slider.Remove(slider);
            return View("Slider");
        }
        #endregion

        #region Category
        public ActionResult Category()
        {
            var category = db.Category.ToList();
            return View(category);
        }

        public ActionResult CategoryDetails(int? id)
        {
            if (id == null)
            {
            }

            var category = db.Category.Find(id);

            if (category == null)
            {
            }

            return View(category);
        }

        [HttpGet]
        public ActionResult CategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CategoryAdd(Category category)
        {
            //log l = new log();

            if (ModelState.IsValid)
            {
                db.Category.Add(category);

                //Loglama
                // l.name = Kategori;
                //l.status = "Kategori Eklendi";
                //l.explanation = "Kategori Adı: " + category.Name;
                //l.date = DateTime.Now();
                //db.log.Add(l);
                db.SaveChanges();
                return RedirectToAction("Category");
            }
            else
            {
                return View(category);
            }
        }

        [HttpGet]
        public ActionResult CategoryUpdate(int? id)
        {
            if (id == null)
            {
            }

            var category = db.Category.Find(id);

            if (category == null)
            {
            }

            return View(category);
        }

        [HttpPost]
        public ActionResult CategoryUpdate(int id, Category category)
        {
            var categories = db.Category.Find(id);

            categories.Name = category.Name;
            categories.Description = category.Description;
            db.SaveChanges();
            return RedirectToAction("Category");
        }

        [HttpGet]
        public ActionResult CategoryDelete(int? id)
        {
            if (id == null)
            {
            }

            var category = db.Category.Find(id);

            if (category == null)
            {
            }

            category.Status = false;
            db.SaveChanges();
            return View("Category");
        }
        #endregion

        #region Comment
        public ActionResult Comment()
        {
            var article = db.Comment.OrderByDescending(x => x.Id).Where(x => x.Status == true).ToList();
            return View(article);

            //var comment = db.Comment.ToList();
            //return View(comment);
        }

        public ActionResult CommentActive(int? id)
        {
            if (id == null)
            {

            }

            var key = db.Comment.Find(id);

            if (key == null)
            {

            }

            key.Status = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CommentDetail(int? id)
        {
            if (id == null)
            {
            }

            var comment = db.Comment.Find(id);

            if (comment == null)
            {
            }

            return View(comment);
        }

        [HttpGet]
        public ActionResult CommentUpdate(int? id)
        {
            if (id == null)
            {
            }

            var comment = db.Comment.Find(id);

            if (comment == null)
            {
            }

            return View(comment);
        }

        [HttpPost]
        public ActionResult CommentUpdate(int id, Comment comment)
        {
            var commentUpdate = db.Comment.Find(id);

            commentUpdate.Message = comment.Message;
            db.SaveChanges();
            return RedirectToAction("Comment");
        }

        public ActionResult CommentDelete(int id)
        {
            var comment = db.Comment.Find(id);
            db.Comment.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion

        public ActionResult CommentMessage()
        {
            var comment = db.Comment.OrderByDescending(x => x.Id).ToList();
            return View(comment);
        }

        public ActionResult CommentMes(int? id)
        {
            if (id == null)
            {

            }

            var comment = db.Comment.Find(id);

            if (comment == null)
            {

            }

            ac.Comment = db.Comment.Where(x => x.Id == id).ToList();
            ac.Reply = db.Reply.Where(x => x.CommentId == id).ToList();

            return View(ac);
        }

        [HttpGet]
        public ActionResult CommentReply(int? id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult CommentReply(int id, Reply reply)
        {
            var key = db.Comment.Find(id);

            var email = (string)Session["email"];
            var uye = db.Writer.FirstOrDefault(x => x.Email == email);

            reply.CommentId = id;
            reply.Date = DateTime.Now;
            reply.Email = uye.Email;
            reply.NameSurName = uye.Name + " " + uye.SurName;
            reply.Status = true;
            db.Reply.Add(reply);
            db.SaveChanges();
            return RedirectToAction("CommentReply");
        }


        #region Writer
        public ActionResult Writer()
        {
            var writer = db.Writer.Where(x => x.Status == true).ToList();
            return View(writer);
        }

        public ActionResult WriterDetail(int? id)
        {
            if (id == null)
            {
            }
            var writer = db.Writer.Find(id);
            var article = db.Article.Where(x => x.WriterId == id).Count();
            var reading = db.Article.Where(x => x.WriterId == id).Sum(x => x.ReadingCount);

            var like = db.ArticleLike.Where(x => x.Article.WriterId == id).Count();

            ViewBag.Article = article;
            ViewBag.Reading = reading;
            ViewBag.Like = like;

            if (writer == null)
            {
            }

            return View(writer);
        }

        [HttpGet]
        public ActionResult WriterChat(int? id)
        {
            var key = db.Writer.Find(id);

            if (id != null)
            {
                ViewBag.FullName = key.Name + " " + key.SurName;
            }

            var writer = db.Writer.Where(x => x.Status == true).Take(8).ToList();
            return View(writer);
        }

        [HttpPost]
        public ActionResult WriterChat(int id, WriterChat writerChat)
        {
            return RedirectToAction("WriterChat");
        }

        [HttpGet]
        public ActionResult WriterChatMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterChatMessage(Writer writer)
        {
            return RedirectToAction("WriterChat");
        }

        public ActionResult WriterComment(int? id)
        {
            if (id == null)
            {
            }

            var writer = db.Writer.Find(id);

            var article = db.Article.Where(x => x.WriterId == id).ToList();
            return View();
        }

        [HttpGet]
        public ActionResult WriterAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterAdd(Writer writer)
        {
            if (ModelState.IsValid)
            {
                db.Writer.Add(writer);
                db.SaveChanges();
                return RedirectToAction("Writer");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult WriterUpdate(int? id)
        {
            if (id == null)
            {
            }

            var writer = db.Writer.Find(id);

            if (writer == null)
            {
            }

            return View(writer);

        }

        [HttpPost]
        public ActionResult WriterUpdate(int id, Writer w)
        {
            var writer = db.Writer.Find(id);

            writer.Image = w.Image;
            db.SaveChanges();
            return RedirectToAction("Writer");
        }

        [HttpPost]
        public ActionResult WriterDelete(int? id)
        {
            if (id == null)
            {
            }

            var writer = db.Writer.Find(id);

            if (writer == null)
            {
            }

            writer.Status = false;
            db.SaveChanges();
            return RedirectToAction("Writer");
        }

        //[HttpPost]
        //public ActionResult WriterChatMessage(int id, WriterChat writerchat)
        //{
        //    var member = (string)Session["email"];
        //    var writer = db.Writer.FirstOrDefault(x => x.Email == member);

        //    if (writer == null)
        //    {
        //        var writerMember = db.Member.FirstOrDefault(x => x.Email == member);
        //        writerchat.MemberId = writerMember.Id;
        //        writerchat.WriterId = id;
        //        writerchat.Status = true;
        //    }
        //    else
        //    {
        //        writerchat.WriterId = writer.Id;
        //        writerchat.MemberId = id;
        //        writerchat.Status = true;
        //    }
        //    db.WriterChat.Add(writerchat);
        //    db.SaveChanges();
        //    return RedirectToAction("WriterChatMessage");
        //}
        #endregion

        #region Article
        public ActionResult Article()
        {
            var article = db.Article.ToList();
            return View(article);
        }

        public ActionResult ArticleDetail(int? id)
        {
            if (id == null)
            {
            }

            var key = db.Article.Find(id);

            ac.Article = db.Article.Where(x => x.Id == id).ToList();
            ac.Tag = db.Tag.Where(x => x.ArticleId == id).ToList();
            ac.Images = db.Images.Where(x => x.ArticleId == id).ToList();
            ViewBag.nameSurname = key.Writer.Name + " " + key.Writer.SurName;

            if (key == null)
            {
            }

            return View(ac);
        }

        public ActionResult ArticlePassive(int id)
        {
            var article = db.Article.Find(id);
            article.Status = false;
            db.SaveChanges();
            return RedirectToAction("Article");
        }

        public ActionResult ArticleActive(int id)
        {
            var article = db.Article.Find(id);
            article.IsActive = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ArticleAdd()
        {
            ViewBag.categoryId = new SelectList(db.Category.Where(x => x.Status == true), "Id", "Name");
            ViewBag.bloodGroupID = new SelectList(db.Tag, "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult ArticleAdd(Article article)
        {
            Images i = new Images();
            Tag t = new Tag();

            var email = (string)Session["email"];
            var uye = db.Writer.FirstOrDefault(x => x.Email == email);

            ViewBag.categoryId = new SelectList(db.Category, "Id", "Name", article.CategoryId);

            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    string dosyaAdi = Path.GetFileName(file.FileName);
                    string uzanti = Path.GetExtension(file.FileName);
                    string adres = "~/Image/article/" + dosyaAdi + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(adres));
                    article.Image = "/Image/article/" + dosyaAdi;
                    article.WriterId = uye.Id;
                    article.Date = DateTime.Now;
                    db.Article.Add(article);
                    db.SaveChanges();
                    return RedirectToAction("Article");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult ArticleUpdate(int? id)
        {
            ViewBag.categoryId = new SelectList(db.Category.Where(x => x.Status == true), "Id", "Name");

            if (id == null)
            {
            }

            var article = db.Article.Find(id);

            if (article == null)
            {
            }

            return View(article);
        }

        [HttpPost]
        public ActionResult ArticleUpdate(int id, Article a)
        {
            ViewBag.categoryId = new SelectList(db.Category, "Id", "Name", a.CategoryId);
            var article = db.Article.Find(id);
            a.Status = true;
            article.Title = a.Title;
            article.Explanation = a.Explanation;
            article.Image = a.Image;
            db.SaveChanges();
            return RedirectToAction("Article");
        }

        [HttpGet]
        public ActionResult ArticleDelete(int id)
        {
            var article = db.Article.Find(id);

            db.Article.Remove(article);
            db.SaveChanges();
            return RedirectToAction("Article");
        }

        [HttpGet]
        public ActionResult ArticleSlider(int id, Slider slider)
        {
            var article = db.Article.Find(id);

            if (article.Slider == true)
            {
                article.Slider = false;
                var sliderFind = db.Slider.Where(x => x.Title == article.Title).FirstOrDefault();
                db.Slider.Remove(sliderFind);
            }
            else
            {
                article.Slider = true;
                slider.ArticleId = id;
                slider.Image = article.Image;
                slider.Title = article.Title;
                slider.Explanation = article.Explanation.Substring(0, 150);
                db.Slider.Add(slider);
            }

            db.SaveChanges();
            return RedirectToAction("Article");
        }

        public ActionResult ArticleActive(int? id)
        {
            if (id == null)
            {

            }

            var key = db.Article.Find(id);

            if (key == null)
            {

            }

            key.IsActive = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ArticleTag()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ArticleTag(int id, Tag tag)
        {
            var key = db.Tag.Find(id);
            tag.ArticleId = id;
            tag.Date = DateTime.Now;
            tag.Status = true;
            db.Tag.Add(tag);
            db.SaveChanges();
            return RedirectToAction("ArticleTag");
        }

        [HttpGet]
        public ActionResult ArticleImages()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ArticleImages(int id, Images ımages, HttpPostedFileBase[] Images)
        {
            var key = db.Article.Find(id);

            if (Images == null || Images.Length == 0)
            {
                return Content("File(s) not selected");
            }
            else
            {
                foreach (HttpPostedFileBase file in Images)
                {
                    var InputFileName = Path.GetFileName(file.FileName);
                    var ServerSavePath = Path.Combine(Server.MapPath("~/Image/article/") + InputFileName);
                    // Save file to server folder
                    file.SaveAs(ServerSavePath);
                    //assigning file uploaded status to ViewBag for showing message to user.
                    ViewBag.UploadStatus = Images.Count().ToString() + "files uploaded successfully.";
                }
                ımages.ArticleId = id;
                db.Images.Add(ımages);
                db.SaveChanges();
                return RedirectToAction("ArticleImages");
            }
        }
        #endregion

        public ActionResult Images()
        {
            var imageList = db.Images.ToList();
            return View(imageList);
        }
    }
}