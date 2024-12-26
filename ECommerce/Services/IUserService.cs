using ECommerce.Models;

namespace ECommerce.Services
{
	public interface IUserService
	{
		User Login(string username, string password);
		void Register(User user);
	}
}
