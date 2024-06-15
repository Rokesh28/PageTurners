using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PageTurners.Models
{
	public class Category
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(50)]
		[DisplayName("Category name")]
		public string Name { get; set; }

		[DisplayName("Display Order")]
		[Range(1,100,ErrorMessage ="Display Order range must be in 1 - 100")]
		public int DisplayOrder { get; set; }
	}
}

