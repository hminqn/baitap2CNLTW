using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;
using StudentManagement.Services;

namespace StudentManagement.Controllers;

public class BookController(BookStore store) : Controller
{
    [HttpGet]
    public IActionResult Index() => View(store.GetAll());

    [HttpGet]
    public IActionResult Detail(int? id)
    {
        if (!ModelState.IsValid || !id.HasValue || id <= 0)
            return BadRequest("Id sách phải là số nguyên lớn hơn 0.");

        var book = store.Find(id.Value);
        return book is null ? NotFound("Không tìm thấy sách.") : View(book);
    }

    [HttpGet]
    public IActionResult Create() => View(new BookInput());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(BookInput input)
    {
        if (!ModelState.IsValid)
            return View(input);

        store.Add(input.Name!.Trim(), input.Price!.Value);
        TempData["Success"] = "Thêm sách thành công";
        // Redirect tránh thêm lại sách khi người dùng refresh trang kết quả.
        return RedirectToAction(nameof(Index));
    }
}
