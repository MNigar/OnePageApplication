using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication7.Db;
using WebApplication7.Model.ViewModel;
using WebApplication7.DbModel;
using WebApplication7.Filter;

namespace WebApplication7.Controllers
{  [Auth]
    public class HomeController : Controller
    {
        private EscanorContext db = new EscanorContext();

        public ActionResult Index()
        {
            ViewBag.Menus = db.Menus.ToList().Where(x=>x.IsVisible).OrderBy(x=>x.Orderby);
            ViewBag.Setting = db.Settings.FirstOrDefault();
            ViewBag.SocialMedia = db.SocialMedias.ToList();
            HomeViewModel model = new HomeViewModel();
            model.Feature = db.Features.ToList();
            model.About = db.Abouts.FirstOrDefault();
            model.Service = db.Services.FirstOrDefault();
            model.ServiceComponent = db.ServiceComponents.ToList();
            model.Price = db.Prices.FirstOrDefault();
            model.Skills = db.Skills.ToList();
            model.Categories = db.Categories.ToList();
            model.Projects = db.Projects.ToList();
            model.Posts = db.Posts.ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session["email"] = null;
            return View("~/Areas/Manage/Views/User/Login.cshtml");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
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