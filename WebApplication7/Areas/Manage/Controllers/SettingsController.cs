using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication7.Db;
using WebApplication7.DbModel;

namespace WebApplication7.Areas.Manage.Controllers
{
    public class SettingsController : Controller
    {
        private EscanorContext db = new EscanorContext();

        // GET: Manage/Settings
        public ActionResult Index()
        {
            return View(db.Settings.ToList());
        }

        // GET: Manage/Settings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Setting setting = db.Settings.Find(id);
            if (setting == null)
            {
                return HttpNotFound();
            }
            return View(setting);
        }

        // GET: Manage/Settings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manage/Settings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Logo,Title,SubTitle,Email,PhoneNumber,Address,SubFooterText,IntroPhoto")] Setting setting, HttpPostedFileBase IntroPhoto)
        {   
            if( IntroPhoto.ContentLength> 1048576)
            {
                Session["imageError"] = "Invalid file size";
                return RedirectToAction("Create");
            }

            if (IntroPhoto.ContentType != "image/jpeg" && IntroPhoto.ContentType != "image/jpg" && IntroPhoto.ContentType != "image/png")
            {
                Session["imageError"] = "File type must be jpg, jpeg, png";
                return RedirectToAction("Create");


            }
            if (ModelState.IsValid)
            {
                string fName = IntroPhoto.FileName;
                string path = Path.Combine(Server.MapPath("~/Uploads"), fName);
                IntroPhoto.SaveAs(path);
                setting.IntroPhoto = fName;
                db.Settings.Add(setting);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(setting);
        }

        // GET: Manage/Settings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Setting setting = db.Settings.Find(id);
            if (setting == null)
            {
                return HttpNotFound();
            }
            return View(setting);
        }

        // POST: Manage/Settings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Logo,Title,SubTitle,Email,PhoneNumber,Address,SubFooterText,IntroPhoto")] Setting setting, HttpPostedFileBase IntroPhoto)
        {
            if (IntroPhoto != null)
            {


                if (IntroPhoto.ContentLength > 1048576)
                {
                    Session["imageError"] = "Invalid file size";
                    return RedirectToAction("Edit", "Settings", new { id = setting.Id });
                }
                if (IntroPhoto.ContentType != "image/jpeg" && IntroPhoto.ContentType != "image/jpg" && IntroPhoto.ContentType != "image/png")
                {
                    Session["imageError"] = "File type must be jpg, jpeg, png";
                    return RedirectToAction("Edit", "Settings", new { id = setting.Id });
                }


                string fName = DateTime.Now.ToString("yyMMddHHmmss") + IntroPhoto.FileName;
                string path = Path.Combine(Server.MapPath("~/Uploads"), fName);
                IntroPhoto.SaveAs(path);
                setting.IntroPhoto = fName;
                Setting currentSetting = db.Settings.Find(setting.Id);
                System.IO.File.Delete(Path.Combine(Server.MapPath("~/Uploads"), currentSetting.IntroPhoto));

                db.Entry(currentSetting).State = EntityState.Detached;

     

            
            
            }

            if (ModelState.IsValid)
            {
                db.Entry(setting).State = EntityState.Modified;
                if (IntroPhoto == null)
                {
                    db.Entry(setting).Property(p => p.IntroPhoto).IsModified = false;
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(setting);
        }

        // GET: Manage/Settings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Setting setting = db.Settings.Find(id);
            if (setting == null)
            {
                return HttpNotFound();
            }
            return View(setting);
        }

        // POST: Manage/Settings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Setting setting = db.Settings.Find(id);
            db.Settings.Remove(setting);
            db.SaveChanges();
            return RedirectToAction("Index");
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
