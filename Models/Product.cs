using System.ComponentModel.DataAnnotations;

namespace MVC01_BY_MennaTarek.Models
{
	public class Product
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Name is required")]
		[StringLength(50, MinimumLength = 3)]
		public string Name { get; set; } = null!;

		[Range(1, 1000000, ErrorMessage = "Price must be greater than 0")]
		public decimal Price { get; set; }

		[StringLength(200)]
		public string? Description { get; set; }

		public int Quantity { get; set; }
	}
}