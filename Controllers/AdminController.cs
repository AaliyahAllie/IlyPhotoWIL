using Microsoft.AspNetCore.Mvc;

namespace IlyPhotoFrontend.Controllers;

public class AdminController : Controller
{
    private bool IsAdmin() => HttpContext.Session.GetString("Role") == "Admin";
    private IActionResult Guard() => RedirectToAction("Login", "Account");

    public IActionResult Index() => IsAdmin() ? View() : Guard();
    public IActionResult Bookings() => IsAdmin() ? View() : Guard();
    public IActionResult Invoices() => IsAdmin() ? View() : Guard();
    public IActionResult Galleries() => IsAdmin() ? View() : Guard();
    public IActionResult Clients() => IsAdmin() ? View() : Guard();
    public IActionResult Services() => IsAdmin() ? View() : Guard();
}
