using ECommerce.Models;
using ECommerce.Repository;

namespace ECommerce.Services
{
	public class UserService : IUserService
	{
		IUserRepository _userRepository;

		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public User Login(string username,string password)
		{
			var users = _userRepository.GetAllUsers();
			foreach (User user in users)
			{
				if (user.Username == username && user.Password == password)
				{
					return user;
				}
			}
			return null;
		}

		public void Register(User newUser)
		{
			_userRepository.Add(newUser);
		}

	}
}
