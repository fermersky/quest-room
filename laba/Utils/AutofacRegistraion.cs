using Autofac;
using Autofac.Integration.Mvc;
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
                .Register(ctor => 
                    new CustomRespository<QuestRoom>(QuestRoomsSeed.GetSeed()))
                .As<IRepository<QuestRoom>>().SingleInstance();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}