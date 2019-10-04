using ExampleHelloASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExampleHelloASP.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet] // attr
        [Route("")] // attr, similar to decorator in flask
        public ViewResult Index()
        {

            string[] places = new string[]
            {
            "Longyearbyen", "Oahu", "Cliffs of Moher", "Solovetsky Islands", "Socotra", "Bhutan", "Hell"
            };

            User guest = new User()
            {
                FirstName = "Lousy",
                LastName = "Tourist",
                Email = "lt@lt.com",
            };


            HomePage homePageModel = new HomePage(guest, places);
            homePageModel.FirstName = "YIKES";

            // ViewBag.places = places;
            // ViewBag.guest = guest;
            return View("Index", homePageModel);
            // return View(guest);
        }

        [HttpGet]
        [Route("place/{destination}")]
        public ViewResult VisitPlace(string destination)
        {
            return View(destination.Replace(" ", ""));
        }

        [HttpPost("/register")]
        public IActionResult Register(User newUser)
        {
            return View("UserProfile", newUser);
        }

        [HttpGet]
        [Route("{*path}")]
        public RedirectToActionResult Unknown(string path)
        {
            return RedirectToAction("Index"); // redirect to Index method/'action'
        }
    }
}