using System.ComponentModel.DataAnnotations;

namespace EventEase.Models
{
	public class User
	{
		[Required(ErrorMessage = "User name is required.")]
		public string Name { get; set; }

		[EmailAddress(ErrorMessage = "Invalid email address.")]
		public string Email { get; set; }
	}
}