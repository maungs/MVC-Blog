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
    public class SocialBlogStatController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /SocialBlogStat/
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            var socialblogstats = db.SocialBlogStats.Include(s => s.Blog);
            return View(socialblogstats.ToList());
        }

        //
        // GET: /SocialBlogStat/Details/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Details(int id = 0)
        {
            SocialBlogStat socialblogstat = db.SocialBlogStats.Find(id);
            if (socialblogstat == null)
            {
                return HttpNotFound();
            }
            return View(socialblogstat);
        }

        //
        // GET: /SocialBlogStat/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            ViewBag.BlogId = new SelectList(db.Blogs, "Id", "Title");
            return View();
        }

        //
        // POST: /SocialBlogStat/Create
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult Create(SocialBlogStat socialblogstat)
        {
            if (ModelState.IsValid)
            {
                db.SocialBlogStats.Add(socialblogstat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BlogId = new SelectList(db.Blogs, "Id", "Title", socialblogstat.BlogId);
            return View(socialblogstat);
        }

        //
        // GET: /SocialBlogStat/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id = 0)
        {
            SocialBlogStat socialblogstat = db.SocialBlogStats.Find(id);
            if (socialblogstat == null)
            {
                return HttpNotFound();
            }
            ViewBag.BlogId = new SelectList(db.Blogs, "Id", "Title", socialblogstat.BlogId);
            return View(socialblogstat);
        }

        //
        // POST: /SocialBlogStat/Edit/5
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult Edit(SocialBlogStat socialblogstat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(socialblogstat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BlogId = new SelectList(db.Blogs, "Id", "Title", socialblogstat.BlogId);
            return View(socialblogstat);
        }

        //
        // GET: /SocialBlogStat/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id = 0)
        {
            SocialBlogStat socialblogstat = db.SocialBlogStats.Find(id);
            if (socialblogstat == null)
            {
                return HttpNotFound();
            }
            return View(socialblogstat);
        }

        //
        // POST: /SocialBlogStat/Delete/5
        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            SocialBlogStat socialblogstat = db.SocialBlogStats.Find(id);
            db.SocialBlogStats.Remove(socialblogstat);
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