using StudentManagement.Models;

namespace StudentManagement.Services;

// Dữ liệu bài thực hành lưu trong bộ nhớ, dùng chung giữa các request.
public class BookStore
{
    private readonly object gate = new();
    private readonly List<Book> books =
    [
        new(1, "Clean Code", 20),
        new(2, "ASP.NET MVC", 15),
        new(3, "Design Pattern", 25)
    ];
    private int nextId = 4;

    public IReadOnlyList<Book> GetAll()
    {
        lock (gate) return books.ToArray();
    }

    public Book? Find(int id)
    {
        lock (gate) return books.Find(book => book.Id == id);
    }

    public void Add(string name, decimal price)
    {
        lock (gate) books.Add(new Book(nextId++, name, price));
    }
}
