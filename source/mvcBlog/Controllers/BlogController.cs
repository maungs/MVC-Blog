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
    public class BlogController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /Blog/
        public ActionResult Index()
        {
            return View(db.Blogs.ToList());
        }

        //
        // GET: /Blog/Details/5
        public ActionResult Details(int id = 0)
        {
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            SetCategoryList(id);
            return View(blog);
        }
        private void SetCategoryList(int id =0)
        {
            string BlogTags = id>0?string.Join(",",(from p in db.Blogs.Find(id).Tags select p.Name)):"";
            List<string> AllCategories = (from p in db.Categorys select p.Name).ToList();
            List<string> SelectedCategories = id>0?(from p in db.Blogs.Find(id).Categories select p.Name).ToList(): new List<String>();
            ViewBag.AllCategories = AllCategories;
            ViewBag.SelectedCategories = SelectedCategories;
            ViewBag.BlogTags = BlogTags;
        }
        //
        // GET: /Blog/Create
        [Authorize(Roles = "Administrator,Blogger")]
        public ActionResult Create()
        {
            SetCategoryList();
            return View();
        }

        //
        // POST: /Blog/Create
        [Authorize(Roles = "Administrator,Blogger")]
        [HttpPost]
        public ActionResult Create(Blog blog, string[] Cat, string BlogTags)
        {
            if (ModelState.IsValid)
            {
                string[] blogtags = BlogTags.Split(',');
                string[] tags = (from p in db.Tags select p.Name).ToArray();
                string[] differenceQuery = blogtags.Except(tags).ToArray();
                foreach(string t in differenceQuery)
                { 
                    Tag tempTag = new Tag();
                    tempTag.Id = 0;
                    tempTag.Name = t.TrimStart().TrimEnd();
                    tempTag.Blogs= null;
                    db.Tags.Add(tempTag);
                    db.SaveChanges();
                }
                blog.Tags = (from p in db.Tags where blogtags.Contains(p.Name) select p).ToList();
                blog.Categories = (from p in db.Categorys where Cat.Contains(p.Name) select p).ToList();
                db.Blogs.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        //
        // GET: /Blog/Edit/5
        [Authorize(Roles = "Administrator,Blogger")]
        public ActionResult Edit(int id = 0)
        {
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            SetCategoryList(id);
            return View(blog);
        }

        //
        // POST: /Blog/Edit/5
        [Authorize(Roles = "Administrator,Blogger")]
        [HttpPost]
        public ActionResult Edit(Blog blog, string[] Cat, string BlogTags)
        {
            if (ModelState.IsValid)
            {
                string[] blogtags = BlogTags.Split(',');
                string[] tags = (from p in db.Tags select p.Name).ToArray();
                string[] differenceQuery = blogtags.Except(tags).ToArray();
                foreach (string t in differenceQuery)
                {
                    Tag tempTag = new Tag();
                    tempTag.Id = 0;
                    tempTag.Name = t.TrimStart().TrimEnd();
                    tempTag.Blogs = null;
                    db.Tags.Add(tempTag);
                    db.SaveChanges();
                }
                blog.Tags = (from p in db.Tags where blogtags.Contains(p.Name) select p).ToList();
                blog.Categories = (from p in db.Categorys where Cat.Contains(p.Name) select p).ToList();

                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blog);
        }

        //
        // GET: /Blog/Delete/5
        [Authorize(Roles = "Administrator,Blogger")]
        public ActionResult Delete(int id = 0)
        {
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        //
        // POST: /Blog/Delete/5
        [Authorize(Roles = "Administrator,Blogger")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Blogs.Find(id);
            db.Blogs.Remove(blog);
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