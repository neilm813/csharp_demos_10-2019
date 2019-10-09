using System.Collections.Generic;
using System.Linq;
using ForumDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForumDemo.Controllers
{
    public class PostsController : Controller
    {
        private ForumContext _db;
        public PostsController(ForumContext context)
        {
            _db = context;
        }

        [HttpGet("posts/all")]
        public IActionResult All()
        {
            List<Post> allPosts = _db.Posts.ToList();
            return View(allPosts);
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
                _db.Posts.Add(newPost);
                _db.SaveChanges();
                return RedirectToAction("All");
            }
            else
            {
                return View("New");
            }
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