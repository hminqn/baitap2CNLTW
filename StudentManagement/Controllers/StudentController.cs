using Microsoft.AspNetCore.Mvc;

namespace StudentManagement.Controllers;

public class StudentController : Controller
{
    public IActionResult Info()
    {
        ViewBag.Name = "Nguyễn Văn A";
        ViewData["Age"] = 20;

        // Truyền Major bằng Model. Ép kiểu object để MVC chọn View(model).
        return View((object)"CNTT");
    }
}
