using Microsoft.AspNetCore.Mvc;

namespace StudentManagement.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return Content("Welcome to ASP.NET MVC", "text/plain; charset=utf-8");
    }

    public IActionResult About()
    {
        // Thay bằng tên của bạn.
        return Content("Nguyễn Văn A", "text/plain; charset=utf-8");
    }

    public IActionResult Contact()
    {
        // Thay bằng email của bạn.
        return Content("nguyenvana@example.com", "text/plain; charset=utf-8");
    }
}
