using System.Collections.Generic;
using UsersServer.Group;

namespace UsersServer.User
{
    public class UserModel
    {
        public virtual int UserId { get; set; }
        public virtual string Username { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Password { get; set; }
        public virtual ICollection<GroupModel> Groups { get; set; }
    }
}