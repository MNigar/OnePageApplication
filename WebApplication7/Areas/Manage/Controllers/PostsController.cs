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
    public class PostsController : Controller
    {
        private EscanorContext db = new EscanorContext();

        // GET: Manage/Posts
        public ActionResult Index()
        {   
            
            return View(db.Posts.ToList());
        }

        // GET: Manage/Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Manage/Posts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manage/Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Date,Photo,Tag,Text")] Post post, HttpPostedFileBase Photo)
        {     
            if(Photo.ContentLength> 1048576)
            {
                Session["imageError"] = "Invalid file size";
                return RedirectToAction("Create");
            }
            if(Photo.ContentType!="image/jpeg" && Photo.ContentType!="image/jpg" && Photo.ContentType!= "image/png")
            {
                Session["imageError"] = "File type must be jpg, jpeg, png";
                return RedirectToAction("Create");


            }


            if (ModelState.IsValid)
            {
                string fName = Photo.FileName;
                string path = Path.Combine(Server.MapPath("~/Uploads"), fName);
                Photo.SaveAs(path);
                post.Photo = fName;
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(post);
        }

        // GET: Manage/Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Manage/Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Date,Photo,Tag,Text")] Post post,HttpPostedFileBase Photo )
        {   if (Photo != null)
            {


                if (Photo.ContentLength > 1048576)
                {
                    Session["imageError"] = "Invalid file size";
                   return RedirectToAction("Edit", "Posts", new { id = post.Id });
                }
                if (Photo.ContentType != "image/jpeg" && Photo.ContentType != "image/jpg" && Photo.ContentType != "image/png")
                {
                    Session["imageError"] = "File type must be jpg, jpeg, png";
                    return RedirectToAction("Edit", "Posts", new { id = post.Id });
                }


                string fName  = DateTime.Now.ToString("yyMMddHHmmss") + Photo.FileName;
                string path = Path.Combine(Server.MapPath("~/Uploads"), fName);
                Photo.SaveAs(path);
                post.Photo = fName;
                Post currentPost = db.Posts.Find(post.Id);
                System.IO.File.Delete(Path.Combine(Server.MapPath("~/Uploads"), currentPost.Photo));
                db.Entry(currentPost).State = EntityState.Detached;

            }
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                if (Photo == null)
                {
                    db.Entry(post).Property(p => p.Photo).IsModified = false;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Manage/Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Manage/Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
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
