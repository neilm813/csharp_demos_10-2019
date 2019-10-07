using System.Collections.Generic;
using DbConnection;
using ForumDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForumDemo.Controllers
{
    public class PostsController : Controller
    {
        [HttpGet("posts/all")]
        public IActionResult All()
        {
            List<Dictionary<string, object>> allPosts
                = DbConnector.Query("SELECT * FROM posts");
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
                string insertSql = $@"
                    INSERT INTO posts (Username, Topic, Content)
                    VALUES ('{newPost.Username}', '{newPost.Topic}', '{newPost.Content}')
                ";

                DbConnector.Execute(insertSql);
                return RedirectToAction("All");
            }
            else {
                return View("New");
            }
        }
    }
}