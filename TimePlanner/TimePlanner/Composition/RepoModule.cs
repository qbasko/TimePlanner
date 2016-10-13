using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Services;
using Repository;
using Repository.IRepo;
using Repository.Models;

namespace TimePlanner.Composition
{
    public class RepoModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterAssemblyTypes(typeof(IDetermineRepoAssembly).Assembly).AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<TimePlannerContext>().As<ITimePlannerContext>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            //builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().OnActivated(c =>
            //{
            //    c.Instance.EventRepo = c.Context.Resolve<IEventRepo>();
            //    c.Instance.EventTypeRepo = c.Context.Resolve<IEventTypeRepo>();
            //    c.Instance.LocationRepo = c.Context.Resolve<ILocationRepo>();
            //    c.Instance.UserRepo = c.Context.Resolve<IUserRepo>();
            //}
            //);
        }
    }
}