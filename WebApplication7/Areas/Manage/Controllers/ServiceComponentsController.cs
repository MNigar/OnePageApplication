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
    public class ServiceComponentsController : Controller
    {
        private EscanorContext db = new EscanorContext();

        // GET: Manage/ServiceComponents
        public ActionResult Index()
        {
            return View(db.ServiceComponents.ToList());
        }

        // GET: Manage/ServiceComponents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceComponent serviceComponent = db.ServiceComponents.Find(id);
            if (serviceComponent == null)
            {
                return HttpNotFound();
            }
            return View(serviceComponent);
        }

        // GET: Manage/ServiceComponents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manage/ServiceComponents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Icon,Title,Description,ServiceId")] ServiceComponent serviceComponent)
        {
            if (ModelState.IsValid)
            {
                serviceComponent.ServiceId = db.Services.FirstOrDefault().Id;

                db.ServiceComponents.Add(serviceComponent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(serviceComponent);
        }

        // GET: Manage/ServiceComponents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceComponent serviceComponent = db.ServiceComponents.Find(id);
            if (serviceComponent == null)
            {
                return HttpNotFound();
            }
            return View(serviceComponent);
        }

        // POST: Manage/ServiceComponents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Icon,Title,Description,ServiceId")] ServiceComponent serviceComponent)
        {
            if (ModelState.IsValid)
            {
                serviceComponent.ServiceId = db.Services.FirstOrDefault().Id;

                db.Entry(serviceComponent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(serviceComponent);
        }

        // GET: Manage/ServiceComponents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceComponent serviceComponent = db.ServiceComponents.Find(id);
            if (serviceComponent == null)
            {
                return HttpNotFound();
            }
            return View(serviceComponent);
        }

        // POST: Manage/ServiceComponents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServiceComponent serviceComponent = db.ServiceComponents.Find(id);
            db.ServiceComponents.Remove(serviceComponent);
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
