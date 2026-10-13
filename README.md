# StudentManagement — Bài thực hành ASP.NET MVC

## Bài thực hành bổ sung: Form, quản lý sách và validation

- `/Account/Login`: GET hiển thị form Username/Password. POST nhận `LoginInput` qua model binding và hiển thị `Login success` khi nhập đúng `admin` / `123`, các trường hợp khác hiển thị `Login failed`. Đây là kiểm tra tài khoản mẫu cho bài thực hành, chưa tạo phiên đăng nhập.
- `/Book/Index`: danh sách ban đầu gồm Clean Code (20), ASP.NET MVC (15), Design Pattern (25).
- `/Book/Detail/1`: hiển thị Id, tên và giá sách; id không hợp lệ trả HTTP 400, sách không tồn tại trả HTTP 404.
- `/Book/Create`: GET hiển thị form tên sách/giá; POST thêm sách và chuyển về danh sách với thông báo “Thêm sách thành công”.
- `Models/BookInput.cs` sử dụng Data Annotation: `[Required]` kiểm tra tên rỗng hoặc chỉ có khoảng trắng và `[PositivePrice]` kiểm tra giá lớn hơn 0. Controller kiểm tra `ModelState.IsValid` trước khi thêm; view hiển thị lỗi cạnh trường nhập và giữ dữ liệu đã nhập.
- Form POST dùng antiforgery token do Form Tag Helper sinh ra và `[ValidateAntiForgeryToken]` kiểm tra phía controller.

Sách mới lưu trong bộ nhớ của ứng dụng, xuất hiện trong danh sách và có trang chi tiết. Khi khởi động lại ứng dụng, danh sách trở về 3 sách ban đầu. Dừng ứng dụng đang chạy rồi chạy lại để nhận mã mới.

Project sử dụng ASP.NET Core MVC trên .NET 10, gồm đủ 3 bài tập. Cần .NET 10 SDK để chạy.

## Chạy project

Từ thư mục chứa README này:

```powershell
dotnet run --project StudentManagement
```

Mở trình duyệt tại http://localhost:5050/Home/Index. Nhấn Ctrl+C trong terminal để dừng ứng dụng.

| URL | Kết quả |
| --- | --- |
| `/` hoặc `/Home/Index` | Welcome to ASP.NET MVC |
| `/Home/About` | Nguyễn Văn A |
| `/Home/Contact` | nguyenvana@example.com |
| `/Product/Detail/5` | Product ID = 5 |
| `/Product/Category?name=Laptop` | Category = Laptop |
| `/Student/Info` | Tên: Nguyễn Văn A; Tuổi: 20; Ngành: CNTT |

Tên và email ở bài 1 là dữ liệu mẫu; sửa trong `Controllers/HomeController.cs` để dùng thông tin của bạn.

## Bài 1: Controller và Action

**Controller** là lớp tiếp nhận và xử lý request, kế thừa `Controller`. **Action** là phương thức public trong controller được MVC gọi khi URL phù hợp. `HomeController` có các action `Index`, `About`, `Contact`; các action trả về `Content(...)` để trình duyệt hiển thị văn bản UTF-8.

## Bài 2: Routing và tham số

`Program.cs` đăng ký route `{controller=Home}/{action=Index}/{id?}`. Khi truy cập `/Product/Detail/5`, MVC chọn `ProductController`, gọi `Detail`, rồi gán `id = 5`. Với `/Product/Category?name=Laptop`, model binding đọc query string và gán `name = "Laptop"`.

`Detail` dùng `int?` để phát hiện thiếu id. Thiếu tham số, id không phải số nguyên, id không dương hoặc tên danh mục trống đều trả thông báo bằng tiếng Việt và HTTP 400. Ví dụ: `/Product/Detail`, `/Product/Detail/abc`, `/Product/Detail/0`, `/Product/Category`, `/Product/Category?name=`.

## Bài 3: Truyền dữ liệu sang View

`StudentController.Info` truyền `Name` qua `ViewBag`, `Age` qua `ViewData`, và `Major` qua Model kiểu `string`. View `Views/Student/Info.cshtml` khai báo `@model string`, đọc ba nguồn dữ liệu và hiển thị bằng Razor.

`View((object)"CNTT")` đảm bảo chuỗi được truyền như Model. Nếu gọi `View("CNTT")`, MVC hiểu đó là tên view cần tìm.
