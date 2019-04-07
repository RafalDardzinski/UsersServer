using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersServer.Group
{
    public interface IGroupService
    {
        void Create(string name);

        IList<GroupModel> Read(int id = 0, string name = null);

        void Update(int id, string newName);

        void Delete(int id);
    }
}
