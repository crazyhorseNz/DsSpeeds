using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Data;
using DsSpeeds.App_Start;
using DsSpeeds.DependencyResolution;
using DsSpeeds.Infrastructure.Automapper;

namespace DsSpeeds
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var config = GlobalConfiguration.Configuration;
            var container = StructuremapMvc.StructureMapDependencyScope.Container;
            config.DependencyResolver = new StructureMapDependencyResolver(container);

            MartenDocumentStore.BootMartenDocumentStore();

            AutoMapperMappings.BootAutoMapper();

        }
    }
}
