using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models;

public class BookInput
{
    [Required(ErrorMessage = "Không được để trống")]
    [Display(Name = "Tên sách")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập giá")]
    [PositivePrice]
    [Display(Name = "Giá")]
    public decimal? Price { get; set; }
}

public sealed class PositivePriceAttribute : ValidationAttribute
{
    public PositivePriceAttribute() : base("Giá phải lớn hơn 0") { }

    public override bool IsValid(object? value)
    {
        // Required xử lý giá bị bỏ trống.
        return value is null || value is decimal price && price > 0;
    }
}
