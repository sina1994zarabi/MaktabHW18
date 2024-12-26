using ECommerce.Models;

namespace ECommerce.Repository
{
	public class UserRepository : IUserRepository
	{
		private readonly AppDbContext _context;

		public UserRepository(AppDbContext context)
		{
			_context = context;
		}

		public void Add(User newUser)
		{
			_context.Users.Add(newUser);
			_context.SaveChanges();
		}

		public List<User> GetAllUsers()
		{
			return _context.Users.ToList();
		}
	}
}
