using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace EventEase.Models
{
	public class Card
	{
		public Card()
		{
			Id = RandomNumberGenerator.GetInt32(0, 1000000);
			Date = DateOnly.FromDateTime(DateTime.Today);
		}

		[Required(ErrorMessage = "Event name is required.")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Event date is required.")]
		[FromToday]
		public DateOnly Date { get; set; }

		[Required(ErrorMessage = "Event location is required.")]
		[StringLength(100, ErrorMessage = "Location cannot exceed 100 characters.")]
		public string Location { get; set; }
		public int Id { get; }
	}

	public class FromTodayAttribute : ValidationAttribute
	{
		public FromTodayAttribute() {}

		public static string GetErrorMessage() => "Date must be past now.";

		protected override ValidationResult IsValid(object value, ValidationContext context)
		{
			var date = (DateOnly)value;
			var today = DateOnly.FromDateTime(DateTime.Today);
			if (date < today)
				return new ValidationResult(GetErrorMessage());
			else
				return ValidationResult.Success;
		}
	}
}