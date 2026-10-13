using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;

namespace StudentManagement.Controllers;

public class AccountController : Controller
{
    [HttpGet]
    public IActionResult Login() => View(new LoginInput());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Login(LoginInput input)
    {
        ViewBag.Message = input.Username == "admin" && input.Password == "123"
            ? "Login success"
            : "Login failed";

        // Không đưa mật khẩu đã submit trở lại HTML.
        input.Password = null;
        ModelState.Remove(nameof(LoginInput.Password));
        return View(input);
    }
}
