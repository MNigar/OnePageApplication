using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication7.Filter;

namespace WebApplication7.Areas.Manage.Controllers
{
    public class HomeController : Controller
    {
        [Auth]
        // GET: Manage/Home
        public ActionResult Index()
        {

            return View();
        }
    }
}