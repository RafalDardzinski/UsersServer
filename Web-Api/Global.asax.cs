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
using Web_Api.App_Start;

namespace Web_Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private readonly ICoreFactory _coreFactory = new CoreFactory();
        private HttpConfiguration _httpConfig = GlobalConfiguration.Configuration;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            InitializeIoC();
        }

        private void InitializeIoC()
        {
          var container = new IoC(_coreFactory, _httpConfig).GetContainer();
          _httpConfig.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        protected void Application_End(ISession session)
        {
          session.Close();
        }

    }
}
