using System.Collections.Generic;

namespace UsersServer.Group
{
    /// <summary>
    /// Provides methods to manage groups.
    /// </summary>
    public interface IGroupService
    {
        void Create(string name);

        IList<GroupModel> Read(int id = 0, string name = null);

        void Update(int id, string newName);

        void Delete(int id);
    }
}
