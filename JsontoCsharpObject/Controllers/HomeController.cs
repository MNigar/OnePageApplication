using JsontoCsharpObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JsontoCsharpObject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var jslist = "{ \"autos\":[{\"marka\":\"audi\",\"model\":\"a5\"},{\"marka\":\"bmw\",\"model\":\"530\"}]}";
        var csharobj= Newtonsoft.Json.JsonConvert.DeserializeObject<JsList>(jslist);
          

            return View(csharobj);
        }

        public ActionResult IndexViewBag()
        {
            var jslist = "{ \"autos\":[{\"marka\":\"audi\",\"model\":\"a5\"},{\"marka\":\"bmw\",\"model\":\"530\"}]}";
            ViewBag.csharobj= Newtonsoft.Json.JsonConvert.DeserializeObject<JsList>(jslist);
            return View();

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
    }
}