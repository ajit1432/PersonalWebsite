using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PersonalWebsite.Models;

namespace PersonalWebsite.Controllers
{
    public class BlogPostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Blog
        public ActionResult BlogIndex()
        {
            return View(db.Posts.ToList());
        }
        // GET: Blog
        public ActionResult week1()
        {
            return View();
        }
        // GET: Blog
        public ActionResult week2()
        {
            return View();
        }
        // GET: Blog
        public ActionResult week3()
        {
            return View();
        }
        // GET: Blog
        public ActionResult week4()
        {
            return View();
        }
        // GET: Blog
        public ActionResult week5()
        {
            return View();
        }
        // GET: Blog
        public ActionResult week6()
        {
            return View();
        }
        // GET: Blog
        public ActionResult week7()
        {
            return View();
        }
        // GET: Blog
        public ActionResult week8()
        {
            return View();
        }
        // GET: Blog
        public ActionResult week9()
        {
            return View();
        }
        // GET: Blog
        public ActionResult week10()
        {
            return View();
        }
        // GET: Blog
        public ActionResult week11()
        {
            return View();
        }
        // GET: Blog
        public ActionResult week12()
        {
            return View();
        }
        // GET: BlogPosts
        [Authorize(Roles = "Admin, Moderator")]
        public ActionResult AdminIndex()
        {
            return View(db.Posts.ToList());
        }

        // GET: BlogPosts/Details/5
        [Authorize(Roles = "Admin, Moderator")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost blogPost = db.Posts.Find(id);
            if (blogPost == null)
            {
                return HttpNotFound();
            }
            return View(blogPost);
        }

        // GET: BlogPosts/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: BlogPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Created,Updated,title,Slug,Body,MediaURL,Published")] BlogPost blogPost)
        {
            if (ModelState.IsValid)
            {
                db.Posts.Add(blogPost);
                db.SaveChanges();
                return RedirectToAction("AdminIndex");
            }

            return View(blogPost);
        }

        // GET: BlogPosts/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost blogPost = db.Posts.Find(id);
            if (blogPost == null)
            {
                return HttpNotFound();
            }
            return View(blogPost);
        }

        // POST: BlogPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Created,Updated,title,Slug,Body,MediaURL,Published")] BlogPost blogPost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("AdminIndex");
            }
            return View(blogPost);
        }

        // GET: BlogPosts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost blogPost = db.Posts.Find(id);
            if (blogPost == null)
            {
                return HttpNotFound();
            }
            return View(blogPost);
        }

        // POST: BlogPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogPost blogPost = db.Posts.Find(id);
            db.Posts.Remove(blogPost);
            db.SaveChanges();
            return RedirectToAction("AdminIndex");
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
