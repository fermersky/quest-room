using Autofac;
using Autofac.Integration.Mvc;
using laba.DAL;
using laba.Models;
using laba.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace laba.Utils
{
    public class AutofacRegistraion
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // dependencies

            builder
                .RegisterType<QuestRoomRepository>()
                .As<IRepository<QuestRoom>>().SingleInstance();

            builder
                .RegisterType<PhoneNumberRespository>()
                .As<IRepository<PhoneNumber>>().SingleInstance();

            builder
                .RegisterType<EFUnitOfWork>()
                .As<IUnitOfWork>().SingleInstance();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}