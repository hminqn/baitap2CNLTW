var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<StudentManagement.Services.BookStore>();

var app = builder.Build();

// URL: /{controller}/{action}/{id?}. Dấu ? nghĩa là id không bắt buộc.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();