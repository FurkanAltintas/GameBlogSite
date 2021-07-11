using GameBlogSite.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace StudentInformationSystem.Controllers
{
    public class AccountController : Controller
    {
        
        Context db = new Context();
        // GET: Account

        //Giriş
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Writer writer)
        {
            var info = db.Writer.Where(x => x.Email == writer.Email && x.Password == writer.Password).FirstOrDefault();
            if (info != null)
            {
                FormsAuthentication.SetAuthCookie(info.Email, false);
                Session["user"] = info.Name + " " + info.SurName;
                Session["profile"] = info.Image;
                Session["email"] = info.Email;
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ViewBag.Error = "Email veya şifre hatalı";
                return View();
            }
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Member member)
        {
            if (member.Password == member.RPassword)
            {
                member.Date = DateTime.Now;
                member.Contract = true;
                member.Status = true;
                db.Member.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View(member);
            }
        }

        public ActionResult ResetPassword(Writer writer)
        {
            var info = db.Writer.Where(x => x.Email == writer.Email && x.Password == writer.Password).FirstOrDefault();
            if (info != null)
            {
                //mail atma
                db.SaveChanges();
                return RedirectToAction("Login", "Account");
            }
            else
            {
                ViewBag.Error = "There are no such students in the system.";
                return View();
            }
        }

        //Çıkış
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}