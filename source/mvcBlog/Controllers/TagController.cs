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
    public class TagController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /Tag/
        [Authorize(Roles = "Administrator, Blogger")]
        public ActionResult Index()
        {
            return View(db.Tags.ToList());
        }

        //
        // GET: /Tag/Details/5
        [Authorize(Roles = "Administrator, Blogger")]
        public ActionResult Details(int id = 0)
        {
            Tag tag = db.Tags.Find(id);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        //
        // GET: /Tag/Create
        [Authorize(Roles = "Administrator, Blogger")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Tag/Create
        [Authorize(Roles = "Administrator, Blogger")]
        [HttpPost]
        public ActionResult Create(Tag tag)
        {
            if (ModelState.IsValid)
            {
                db.Tags.Add(tag);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tag);
        }

        //
        // GET: /Tag/Edit/5
        [Authorize(Roles = "Administrator, Blogger")]
        public ActionResult Edit(int id = 0)
        {
            Tag tag = db.Tags.Find(id);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        //
        // POST: /Tag/Edit/5
        [Authorize(Roles = "Administrator, Blogger")]
        [HttpPost]
        public ActionResult Edit(Tag tag)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tag).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tag);
        }

        //
        // GET: /Tag/Delete/5
        [Authorize(Roles = "Administrator, Blogger")]
        public ActionResult Delete(int id = 0)
        {
            Tag tag = db.Tags.Find(id);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        //
        // POST: /Tag/Delete/5
        [Authorize(Roles = "Administrator, Blogger")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Tag tag = db.Tags.Find(id);
            db.Tags.Remove(tag);
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