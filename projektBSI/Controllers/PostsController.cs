using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using projektBSI.DataAccessLayer;
using projektBSI.Entities;
using projektBSI.Models;

namespace projektBSI.Controllers
{
    public class PostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Posts
        public ActionResult Index()
        {
            return View(db.Posts.ToList());
        }
        [Authorize]
        public ActionResult List()
        {
            string id = User.Identity.GetUserId();

            IQueryable<Post> posts;

            if (!User.IsInRole("Admin"))
            {
                posts = db.Posts.Where(p => p.ApplicationUser.Id == id);
            }
            else
            {
                posts = db.Posts;
            }

            var postModels = posts //Mapper.Map<PostModel>(posts);
                .Select(x =>
                    new PostModel()
                    {
                        Id = x.Id,
                        Title = x.Title,
                        Article = x.Article,
                        UserId = x.UserId,
                        ApplicationUser = x.ApplicationUser,
                        Signature = x.ApplicationUser.Signature
                    });

            return View(postModels);
        }

        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var post = db.Posts.Find(id);

            if (post == null)
            {
                return HttpNotFound();
            }

            return View(post);
        }

        // GET: Posts/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,Title,Article")] Post post, String UserId)
        {
            var userID = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                var postToAdd = new Post
                {
                    Id = post.Id,
                    Title = post.Title,
                    Article = post.Article,
                    UserId = User.Identity.GetUserId(),
                    DateOfPublication = DateTime.Now
                };
                db.Posts.Add(postToAdd);
                db.SaveChanges();
                return RedirectToAction("List");
            }

            return View(post);
        }

        // GET: Posts/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var post = db.Posts.Find(id);

            if (post == null)
            {
                return HttpNotFound();
            }

            return View(post);
        }

        // POST: Posts/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,Title,Article")] Post post)
        {
            ApplicationDbContext x = new ApplicationDbContext();
            Post currentPost = x.Posts.Single(p => p.Id == post.Id);
            if (ModelState.IsValid)
            {
                var postToAdd = new Post
                {
                    Id = post.Id,
                    Title = post.Title,
                    Article = post.Article,
                    UserId = currentPost.UserId,
                    DateOfPublication = currentPost.DateOfPublication
                };

                db.Entry(postToAdd).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("List");
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var post = db.Posts.Find(id);

            if (post == null)
            {
                return HttpNotFound();
            }

            return View(post);
        }
        [Authorize]
        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var post = db.Posts.Find(id);

            db.Posts.Remove(post);
            db.SaveChanges();

            return RedirectToAction("List");
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
