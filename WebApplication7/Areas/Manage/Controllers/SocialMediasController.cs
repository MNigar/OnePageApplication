using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication7.Db;
using WebApplication7.DbModel;

namespace WebApplication7.Areas.Manage.Controllers
{
    public class SocialMediasController : Controller
    {
        private EscanorContext db = new EscanorContext();

        // GET: Manage/SocialMedias
        public ActionResult Index()
        {
            var socialMedias = db.SocialMedias.Include(s => s.Icon).Include(s => s.Setting);
            return View(socialMedias.ToList());
        }

        // GET: Manage/SocialMedias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialMedia socialMedia = db.SocialMedias.Find(id);
            if (socialMedia == null)
            {
                return HttpNotFound();
            }
            return View(socialMedia);
        }

        // GET: Manage/SocialMedias/Create
        public ActionResult Create()
        {
            ViewBag.IconId = new SelectList(db.Icons, "Id", "Icons");
            ViewBag.SettingId = new SelectList(db.Settings, "Id", "Logo");
            return View();
        }

        // POST: Manage/SocialMedias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IconId,SettingId,Link,Name")] SocialMedia socialMedia)
        {
            if (ModelState.IsValid)
            {
                db.SocialMedias.Add(socialMedia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IconId = new SelectList(db.Icons, "Id", "Icons", socialMedia.IconId);
            ViewBag.SettingId = new SelectList(db.Settings, "Id", "Logo", socialMedia.SettingId);
            return View(socialMedia);
        }

        // GET: Manage/SocialMedias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialMedia socialMedia = db.SocialMedias.Find(id);
            if (socialMedia == null)
            {
                return HttpNotFound();
            }
            ViewBag.IconId = new SelectList(db.Icons, "Id", "Icons", socialMedia.IconId);
            ViewBag.SettingId = new SelectList(db.Settings, "Id", "Logo", socialMedia.SettingId);
            return View(socialMedia);
        }

        // POST: Manage/SocialMedias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IconId,SettingId,Link,Name")] SocialMedia socialMedia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(socialMedia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IconId = new SelectList(db.Icons, "Id", "Icons", socialMedia.IconId);
            ViewBag.SettingId = new SelectList(db.Settings, "Id", "Logo", socialMedia.SettingId);
            return View(socialMedia);
        }

        // GET: Manage/SocialMedias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialMedia socialMedia = db.SocialMedias.Find(id);
            if (socialMedia == null)
            {
                return HttpNotFound();
            }
            return View(socialMedia);
        }

        // POST: Manage/SocialMedias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SocialMedia socialMedia = db.SocialMedias.Find(id);
            db.SocialMedias.Remove(socialMedia);
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
