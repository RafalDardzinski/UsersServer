using NHibernate;
using UsersServer.Repository;

namespace UsersServer.User
{
	class UserRepository : Repository<UserModel>, IUserRepository
	{

		public UserRepository(ISession session) : base(session)
		{
		}
	}
}
