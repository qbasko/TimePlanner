using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Services;

namespace TimePlanner.Composition
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IDetermineServicesAssembly).Assembly).AsImplementedInterfaces().InstancePerRequest();
            base.Load(builder);
        }
    }
}