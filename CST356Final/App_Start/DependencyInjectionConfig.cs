using CST356Final.Data;
using CST356Final.Proxies;
using CST356Final.Services;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace CST356Final.App_Start
{
    public class DependencyInjectionConfig
    {
        public static void Register()
        {
            // Create the container
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // Register types
            container.Register<IDataRepository, DataRepository>(Lifestyle.Scoped);
            // Register services
            container.Register<ITeacherService, TeacherService>(Lifestyle.Scoped);
            container.Register<IRestClassProxy, RestClassProxy>(Lifestyle.Scoped);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}