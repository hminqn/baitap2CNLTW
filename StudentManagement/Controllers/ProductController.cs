using Microsoft.AspNetCore.Mvc;

namespace StudentManagement.Controllers;

public class ProductController : Controller
{
    public IActionResult Detail(int? id)
    {
        if (!ModelState.IsValid)
        {
            return ParameterError("Lỗi: id phải là số nguyên hợp lệ.");
        }

        if (!id.HasValue)
        {
            return ParameterError("Lỗi: vui lòng truyền id sản phẩm. Ví dụ: /Product/Detail/5");
        }

        if (id.Value <= 0)
        {
            return ParameterError("Lỗi: id sản phẩm phải lớn hơn 0.");
        }

        return Content($"Product ID = {id.Value}", "text/plain; charset=utf-8");
    }

    public IActionResult Category(string? name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return ParameterError("Lỗi: vui lòng truyền tên danh mục. Ví dụ: /Product/Category?name=Laptop");
        }

        return Content($"Category = {name.Trim()}", "text/plain; charset=utf-8");
    }

    private ContentResult ParameterError(string message)
    {
        return new ContentResult
        {
            Content = message,
            ContentType = "text/plain; charset=utf-8",
            StatusCode = StatusCodes.Status400BadRequest
        };
    }
}
