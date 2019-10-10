using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ForumDemo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace ForumDemo.Controllers
{
    public class HomeController : Controller
    {
        private ForumContext _db;
        public HomeController(ForumContext context)
        {
            _db = context;
        }
        public IActionResult Index()
        {
            int? uid = HttpContext.Session.GetInt32("UserId");
            if (uid != null)
            {
                return RedirectToAction("All", "Posts");
            }
            // When no arg is provided to View
            // It looks for a .cshtml file that
            // matches the method name
            return View();
        }

        public IActionResult Register(User newUser)
        {
            if (ModelState.IsValid)
            {
                bool isEmailTaken =
                    _db.Users.Any(user => newUser.Email == user.Email);

                if (isEmailTaken)
                {
                    ModelState.AddModelError("Email", "Email Taken");
                }
            }

            if (ModelState.IsValid == false)
            {
                return View("Index");
            }

            // No Errors
            // Hash pw
            PasswordHasher<User> hasher = new PasswordHasher<User>();
            newUser.Password = hasher.HashPassword(newUser, newUser.Password);

            _db.Users.Add(newUser);
            _db.SaveChanges();

            HttpContext.Session.SetInt32("UserId", newUser.UserId);
            return RedirectToAction("All", "Posts");
        }

        public IActionResult Login(LoginUser loginUser)
        {
            if (ModelState.IsValid == false)
            {
                return View("Index");
            }
            else
            {
                User dbUser = _db.Users.FirstOrDefault(user => loginUser.LoginEmail == user.Email);

                if (dbUser == null)
                {
                    ModelState.AddModelError("LoginEmail", "Invalid Credentials, ya dummy!");
                }
                else
                {
                    User viewUser = new User
                    {
                        Email = loginUser.LoginEmail,
                        Password = loginUser.LoginPassword
                    };

                    PasswordHasher<User> hasher = new PasswordHasher<User>();

                    PasswordVerificationResult result =
                        hasher.VerifyHashedPassword(viewUser, dbUser.Password, viewUser.Password);

                    // failed pw match
                    if (result == 0)
                    {
                        ModelState.AddModelError("LoginEmail", "Invalid Credentials, ya dummy!");
                    }
                    else
                    {
                        HttpContext.Session.SetInt32("UserId", dbUser.UserId);
                    }
                }
            }
            if (ModelState.IsValid == false)
            {
                // display error messages
                // on the forum they came from
                return View("Index");
            }

            return RedirectToAction("All", "Posts");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
