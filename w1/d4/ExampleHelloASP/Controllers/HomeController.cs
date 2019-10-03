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
      return View();
    }

    [HttpGet]
    [Route("place/{destination}")]
    public ViewResult VisitPlace(string destination)
    {
      return View(destination.Replace(" ", ""));
    }
    [HttpGet]
    [Route("{*path}")]
    public RedirectToActionResult Unknown(string path)
    {
      return RedirectToAction("Index"); // redirect to Index method/'action'
    }
  }
}