using IlyPhotoFrontend.Models;
using Microsoft.AspNetCore.Mvc;

namespace IlyPhotoFrontend.Controllers;

public class AccountController : Controller
{
    [HttpGet] public IActionResult Login() => View(new LoginViewModel());

    [HttpPost]
    public IActionResult Login(LoginViewModel model)
    {
        // FRONTEND DEMO ONLY: replace with real authentication later.
        var isAdmin = model.Email.Trim().Equals("admin@ilyphoto.co.za", StringComparison.OrdinalIgnoreCase);
        HttpContext.Session.SetString("Role", isAdmin ? "Admin" : "Client");
        HttpContext.Session.SetString("UserEmail", model.Email);
        HttpContext.Session.SetString("ClientId", isAdmin ? "ADMIN" : "CL-1001");
        return RedirectToAction("Index", isAdmin ? "Admin" : "Client");
    }

    [HttpGet] public IActionResult Register() => View();
    [HttpPost] public IActionResult Register(string fullName, string email, string password)
    {
        HttpContext.Session.SetString("Role", "Client");
        HttpContext.Session.SetString("UserEmail", email);
        HttpContext.Session.SetString("ClientId", "CL-1001");
        return RedirectToAction("Index", "Client");
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Home");
    }
}
