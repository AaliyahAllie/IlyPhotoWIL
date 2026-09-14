using IlyPhotoFrontend.Models;
using Microsoft.AspNetCore.Mvc;

namespace IlyPhotoFrontend.Controllers;

public class ClientController : Controller
{
    private bool IsClient() => HttpContext.Session.GetString("Role") == "Client";
    private IActionResult Guard() => RedirectToAction("Login", "Account");

    public IActionResult Index() => IsClient() ? View() : Guard();
    public IActionResult Bookings() => IsClient() ? View(new BookingViewModel()) : Guard();
    [HttpPost] public IActionResult Bookings(BookingViewModel model)
    {
        if (!IsClient()) return Guard();
        TempData["BookingMessage"] = "Booking request submitted for photographer approval.";
        return View(model);
    }
    public IActionResult Invoices() => IsClient() ? View() : Guard();
    public IActionResult Gallery() => IsClient() ? View() : Guard();
    public IActionResult Reviews() => IsClient() ? View() : Guard();
    [HttpPost] public IActionResult Reviews(int rating, string review)
    {
        if (!IsClient()) return Guard();
        TempData["ReviewMessage"] = "Thank you. Your review has been saved in this frontend demo.";
        return View();
    }
    public IActionResult Profile() => IsClient() ? View() : Guard();
}
