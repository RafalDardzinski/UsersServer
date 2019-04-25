using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NHibernate;
using UsersServer.Database;
using UsersServer.Factory;
using UsersServer.User;

namespace Web_Api.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUserService _userService;

        public UsersController(ISession session, IServiceFactory serviceFactory)
        {
            _userService = serviceFactory.CreateUserService(session);
        }

        public IEnumerable<UserModel> Get()
        {

            return _userService.Read();
        }

        public UserModel Get(int id)
        {
            return _userService.Read(id).FirstOrDefault();
        }
    }
}
