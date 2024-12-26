using ECommerce.Models;
namespace ECommerce.Repository
{
	public interface IUserRepository
	{
		void Add(User newUser);
		List<User> GetAllUsers();
	}
}
