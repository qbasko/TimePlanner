using Autofac;
using Autofac.Integration.Mvc;
using Repository;
using Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TimePlanner.Composition;

namespace TimePlanner
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ConfigureContainer();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
          
        }

        private void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            //builder.RegisterAssemblyModules(typeof(IDetermineServicesAssembly).Assembly);
            //builder.RegisterAssemblyModules(typeof(IDetermineRepoAssembly).Assembly);
            builder.RegisterAssemblyModules(typeof(MvcApplication).Assembly);
            //builder.RegisterAssemblyModules(typeof(IDetermineTimePlannerAssembly).Assembly);
            //builder.RegisterAssemblyModules(AppDomain.CurrentDomain.GetAssemblies());
            builder.RegisterFilterProvider();
            builder.RegisterSource(new ViewRegistrationSource());

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
         
        }
    }
}
