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
    public class IconsController : Controller
    {
        private EscanorContext db = new EscanorContext();

        // GET: Manage/Icons
        public ActionResult Index()
        {
            return View(db.Icons.ToList());
        }

        // GET: Manage/Icons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Icon icon = db.Icons.Find(id);
            if (icon == null)
            {
                return HttpNotFound();
            }
            return View(icon);
        }

        // GET: Manage/Icons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manage/Icons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Icons,Name")] Icon icon)
        {
            if (ModelState.IsValid)
            {
                db.Icons.Add(icon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(icon);
        }

        // GET: Manage/Icons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Icon icon = db.Icons.Find(id);
            if (icon == null)
            {
                return HttpNotFound();
            }
            return View(icon);
        }

        // POST: Manage/Icons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Icons,Name")] Icon icon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(icon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(icon);
        }

        // GET: Manage/Icons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Icon icon = db.Icons.Find(id);
            if (icon == null)
            {
                return HttpNotFound();
            }
            return View(icon);
        }

        // POST: Manage/Icons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Icon icon = db.Icons.Find(id);
            db.Icons.Remove(icon);
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
