using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication7.Db;
using WebApplication7.Model.ViewModel;
using WebApplication7.DbModel;
namespace WebApplication7.Controllers
{
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
            return View(model);
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