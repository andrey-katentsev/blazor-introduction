using EventEase.Models;

namespace EventEase.Services
{
	public class UserService
	{
		public UserService()
		{
			users = [];
			current = new();
		}
		public void AddUser(User user)
		{
			users.Add(user);
		}
		public bool Login(string email)
		{
			var user = users.Find(user => user.Email == email);
			if (user == null)
				return false;
			current = user;
			return true;
		}
		public User CurrentUser()
		{
			return current;
		}
		private List<User> users;
		private User current;
	}
}