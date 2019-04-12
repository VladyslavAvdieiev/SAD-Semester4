using BusinessLogicLayer.Infrastructure;
using Ninject;
using Ninject.Modules;
using PresentationLayer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace PresentationLayer
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            NinjectModule serviceModule = new ServiceModule("BoardTestDb");
            NinjectModule boardModule = new BoardModule();
            var kernel = new StandardKernel(serviceModule, boardModule);

            var ninjectResolver = new NinjectDependencyResolver(kernel);

            GlobalConfiguration.Configuration.DependencyResolver = ninjectResolver;
        }
    }
}
