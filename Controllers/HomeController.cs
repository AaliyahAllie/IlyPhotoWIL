using Microsoft.AspNetCore.Mvc;

namespace IlyPhotoFrontend.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => View();
    public IActionResult About() => View();
    public IActionResult Packages() => View();
    public IActionResult Portfolio() => View();
}
