using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using NHibernate;
using UsersServer.Factory;
using UsersServer.Group;
using UsersServer.User;

namespace Web_Api.App_Start
{
  public class IoC
  {
    private readonly ICoreFactory _coreFactory;
    private readonly HttpConfiguration _httpConfig;

    public IoC(ICoreFactory coreFactory, HttpConfiguration httpConfig)
    {
      _coreFactory = coreFactory;
      _httpConfig = httpConfig;
    }

    public IContainer GetContainer()
    {
      var configManager = _coreFactory.CreateConfigManager();
      var database = _coreFactory.CreateDatabase();
      database.Connect(configManager);

      var builder = new ContainerBuilder();
      builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
      builder.RegisterWebApiFilterProvider(_httpConfig);
      builder.RegisterType<ServiceFactory>().As<IServiceFactory>();
      builder.RegisterInstance(database.Session.OpenSession()).As<ISession>();
      builder.RegisterType<UserService>().As<IUserService>();
      builder.RegisterType<GroupService>().As<IGroupService>();
      return builder.Build();
    }
  }
}