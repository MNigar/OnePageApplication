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
    public class ProjectsController : Controller
    {
        private EscanorContext db = new EscanorContext();

        // GET: Manage/Projects
        public ActionResult Index()
        {
            var projects = db.Projects.Include(p => p.Category);
            return View(projects.ToList());
        }

        // GET: Manage/Projects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // GET: Manage/Projects/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        // POST: Manage/Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Photo,Description,CategoryId,Name")] Project project, HttpPostedFileBase Photo)
        {
            if (Photo.ContentLength > 1048576)
            {
                Session["imageError"] = "Invalid file size";
                RedirectToAction("Create");
            }
            if (Photo.ContentType != "image/jpeg" && Photo.ContentType != "image/jpg" && Photo.ContentType != "image/png")
            {
                Session["imageError"] = "File type must be jpg, jpeg, png";
                RedirectToAction("Create");


            }


            if (ModelState.IsValid)
            {
                string fName = Photo.FileName;
                string path = Path.Combine(Server.MapPath("~/Uploads"), fName);
                Photo.SaveAs(path);
                project.Photo = fName;
                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", project.CategoryId);
            return View(project);
        }

        // GET: Manage/Projects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", project.CategoryId);
            return View(project);
        }

        // POST: Manage/Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Photo,Description,CategoryId,Name")] Project project, HttpPostedFileBase Photo)
        {
            if (Photo != null)
            {


                if (Photo.ContentLength > 1048576)
                {
                    Session["imageError"] = "Invalid file size";
                    RedirectToAction("Edit", "Projects", new { id = project.Id });
                }
                if (Photo.ContentType != "image/jpeg" && Photo.ContentType != "image/jpg" && Photo.ContentType != "image/png")
                {
                    Session["imageError"] = "File type must be jpg, jpeg, png";
                    RedirectToAction("Edit", "Projects", new { id = project.Id });
                }


                string fName =  DateTime.Now.ToString("yyMMddHHmmss") + Photo.FileName;
                string path = Path.Combine(Server.MapPath("~/Uploads"), fName);
                Photo.SaveAs(path);
                project.Photo = fName;
                Project currentProject = db.Projects.Find(project.Id);
                System.IO.File.Delete(Path.Combine(Server.MapPath("~/Uploads"), currentProject.Photo));
                db.Entry(currentProject).State = EntityState.Detached;

            }


            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                if (Photo == null)
                {
                    db.Entry(project).Property(p => p.Photo).IsModified = false;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", project.CategoryId);
            return View(project);
        }

        // GET: Manage/Projects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Manage/Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
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
