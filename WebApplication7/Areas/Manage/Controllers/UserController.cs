using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebApplication7.Db;
using WebApplication7.DbModel;

namespace WebApplication7.Areas.Manage.Controllers
{
    public class UserController : Controller
    {
        private EscanorContext db = new EscanorContext();
        // GET: Manage/User
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(User user)
        {
            if (ModelState.IsValid)
            {
                user.Password = Crypto.HashPassword(user.Password);

                var check = db.Users.Where(u => u.Email == user.Email).FirstOrDefault();
                if (check == null)
                {

                    db.Users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }

                else
                {
                    Session["RegisterError"] = true;
                    return RedirectToAction("Create");

                }
            }

            return View();
        }



        [HttpPost]
       
        public ActionResult Login( User user)
        {
            if (ModelState.IsValid)
            {
                var check = db.Users.Where(u => u.Email == user.Email).FirstOrDefault();
                if (check != null)
                {


                    if (Crypto.VerifyHashedPassword(check.Password, user.Password))
                    {
                        Session["email"] = check.Email;
                        if (Session["email"].ToString() == "admin@gmail.com")
                        {
                            return View("~/Areas/Manage/Views/Home/Index.cshtml");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home", new { Area = ""});

                        }

                    }

                }
                else
                {
                    Session["LoginError"] = true;


                    //ViewBag.Error = "Yoxdur";
                    return View("Login");
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Logout()
        {
            Session["email"] = null;
            return RedirectToAction("Login", "User");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}