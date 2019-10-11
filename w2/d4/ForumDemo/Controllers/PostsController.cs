using System;
using System.Collections.Generic;
using System.Linq;
using ForumDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForumDemo.Controllers
{
    public class PostsController : Controller
    {
        private ForumContext _db;
        private int? _uid
        {
            get
            {
                return HttpContext.Session.GetInt32("UserId");
            }
        }

        public PostsController(ForumContext context)
        {
            _db = context;
        }

        [HttpGet("posts/all")]
        public IActionResult All()
        {
            int? uid = _uid;

            if (uid == null)
            {
                return RedirectToAction("Index", "Home");
            }
            
            List<Post> allPosts = _db.Posts
                .Include(post => post.Author)
                .ToList();

            User user = _db.Users.FirstOrDefault(u => u.UserId == uid);
            ViewBag.FullName = user.FullName();
            return View(allPosts);
        }

        [HttpGet("post/details/{id}")]
        public IActionResult Details(int id)
        {
            Post selectedPost = _db.Posts
                .Include(post => post.Author)
                .FirstOrDefault(p => p.PostId == id);

            // in case user manually types URL
            if (selectedPost == null)
                RedirectToAction("All");

            ViewBag.Uid = _uid;
            return View(selectedPost);
        }

        [HttpGet("posts/new")]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost("posts/create")]
        public IActionResult Create(Post newPost)
        {

            if (ModelState.IsValid)
            {
                if (_uid != null)
                {
                    newPost.UserId = (int)_uid;

                    _db.Posts.Add(newPost);
                    _db.SaveChanges();
                    return RedirectToAction("All");
                }
                else // no one in session
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View("New");
            }
        }

        [HttpGet("posts/edit")]
        public IActionResult Edit(int id)
        {
            Post toEdit = _db.Posts.FirstOrDefault(p => p.PostId == id);

            if (toEdit == null)
                return RedirectToAction("All");

            return View(toEdit);
        }

        [HttpPost("posts/update")]
        public IActionResult Update(Post editedPost, int id)
        {

            if (ModelState.IsValid)
            {
                Post dbPost = _db.Posts.FirstOrDefault(p => p.PostId == id);

                if (dbPost != null)
                {
                    dbPost.Topic = editedPost.Topic;
                    dbPost.Content = editedPost.Content;
                    dbPost.UpdatedAt = DateTime.Now;

                    _db.Posts.Update(dbPost);
                    _db.SaveChanges();

                    return RedirectToAction("Details", new { id = dbPost.PostId });
                }
            }
            // so error messages will be displayed if any
            return View("Edit", editedPost);
        }

        [HttpGet("posts/delete/{id}")]
        public IActionResult Delete(int id)
        {
            Post postFromDb = _db.Posts.FirstOrDefault(post => post.PostId == id);

            if (postFromDb != null)
            {
                _db.Posts.Remove(postFromDb);
                _db.SaveChanges();
            }

            return RedirectToAction("All");
        }
    }
}