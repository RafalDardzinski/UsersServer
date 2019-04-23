using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.WebApi;
using NHibernate;
using UsersServer.Database;
using UsersServer.Factory;

namespace Web_Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private IDatabase _database;
        private ICoreFactory _coreFactory = new CoreFactory();

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            

            var configManager = _coreFactory.CreateConfigManager();

            _database = _coreFactory.CreateDatabase();
            _database.Connect(configManager);

            var config = GlobalConfiguration.Configuration;
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            SetDependancies(builder);
            builder.RegisterWebApiFilterProvider(config);
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private void SetDependancies(ContainerBuilder builder)
        {
            builder.RegisterType<ServiceFactory>().As<IServiceFactory>();
            builder.RegisterInstance(_database.Session.OpenSession()).As<ISession>();
        }

        protected void Application_BeginRequest()
        {
            //_database.Session.OpenSession();
        }

        protected void Application_EndRequest()
        {
            //_database.Session.CloseSession();
        }
    }
}
