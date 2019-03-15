using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using UsersServer.Database;

namespace UsersServer.User
{
    public class UserRepository : Repository, IRepository
    {
        public UserRepository(IDatabaseManager databaseManager) : base(databaseManager)
        {
        }


        private void AddUser(NHibernate.ISession session)
        {
            Console.WriteLine("User created yo!");
        }

        public void Create(Model model)
        {
            RepositoryCommand cmd = AddUser;
            _databaseManager.Execute(cmd);
        }

        public List<Model> Read()
        {
            throw new NotImplementedException();
        }

        public Model Read(Delegate filterFunc)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }
    }
}
