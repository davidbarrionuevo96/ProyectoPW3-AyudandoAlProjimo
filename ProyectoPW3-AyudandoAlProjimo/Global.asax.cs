using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApiDonaciones;

namespace ProyectoPW3_AyudandoAlProjimo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
#pragma warning disable CS0436 // El tipo entra en conflicto con un tipo importado
            GlobalConfiguration.Configure(WebApiConfig.Register);
#pragma warning restore CS0436 // El tipo entra en conflicto con un tipo importado
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
