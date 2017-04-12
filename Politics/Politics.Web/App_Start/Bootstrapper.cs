using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Politics.Data.Infrastructure;
using Politics.Service;
using System.Reflection;
namespace Politics.Web
{
    public class Bootstrapper
    {
        public static void Run()
        {
            SetDependencyResolver();
        }

        static void SetDependencyResolver()
        {
            var iocBuilder = new ContainerBuilder();

            iocBuilder.RegisterControllers(Assembly.GetExecutingAssembly());
            iocBuilder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            iocBuilder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            iocBuilder.RegisterAssemblyTypes(typeof(RegionRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            iocBuilder.RegisterAssemblyTypes(typeof(RegionService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            IContainer ioc = iocBuilder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(ioc));
        }
    }
}