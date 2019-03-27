using System.Collections.Generic;
using UsersServer.User;

namespace UsersServer.Group
{
    public class GroupModel
    {
        public virtual int GroupId { get; set; }
        public virtual string Name { get; set; }
        public virtual ICollection<UserModel> Users { get; set; }
    }
}
