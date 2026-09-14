namespace IlyPhotoFrontend.Models;

public class LoginViewModel
{
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";
}

public class BookingViewModel
{
    public string EventType { get; set; } = "Matric Ball";
    public DateTime Date { get; set; } = DateTime.Today.AddDays(14);
    public string StartTime { get; set; } = "14:00";
    public string EndTime { get; set; } = "17:00";
    public int Hours { get; set; } = 3;
    public string Location { get; set; } = "Cape Town";
    public string Notes { get; set; } = "";
}
