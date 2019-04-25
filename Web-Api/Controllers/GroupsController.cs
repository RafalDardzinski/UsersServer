using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UsersServer.Group;

namespace Web_Api.Controllers
{
    public class GroupsController : ApiController
    {
      private readonly IGroupService _groupService;

      public GroupsController(IGroupService groupService)
      {
        _groupService = groupService;
      }

      public IEnumerable<GroupModel> Get()
      {
        return _groupService.Read();
      }

      public GroupModel Get(int id)
      {
        return _groupService.Read(id).FirstOrDefault();
      }
  }
}
