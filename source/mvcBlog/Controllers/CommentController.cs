using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcBlog.Models;

namespace mvcBlog.Controllers
{
    public class CommentController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /Comment/
        public ActionResult Index()
        {
            var comments = db.Comments.Include(c => c.Blog);
            return View(comments.ToList());
        }

        //
        // GET: /Comment/Details/5

        public ActionResult Details(int id = 0)
        {
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        //
        // GET: /Comment/Create

        public ActionResult Create()
        {
            ViewBag.BlogId = new SelectList(db.Blogs, "Id", "Title");
            return View();
        }

        //
        // POST: /Comment/Create
        [Authorize(Roles = "Administrator,Blogger,Reader")]
        [HttpPost]
        public ActionResult Create(Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BlogId = new SelectList(db.Blogs, "Id", "Title", comment.BlogId);
            return View(comment);
        }

        //
        // GET: /Comment/Edit/5
        [Authorize(Roles = "Administrator,Blogger,Reader")]
        public ActionResult Edit(int id = 0)
        {
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.BlogId = new SelectList(db.Blogs, "Id", "Title", comment.BlogId);
            return View(comment);
        }

        //
        // POST: /Comment/Edit/5
        [Authorize(Roles = "Administrator,Blogger,Reader")]
        [HttpPost]
        public ActionResult Edit(Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BlogId = new SelectList(db.Blogs, "Id", "Title", comment.BlogId);
            return View(comment);
        }

        //
        // GET: /Comment/Delete/5
        [Authorize(Roles = "Administrator,Reader")]
        public ActionResult Delete(int id = 0)
        {
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        //
        // POST: /Comment/Delete/5
        [Authorize(Roles = "Administrator,Reader")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}