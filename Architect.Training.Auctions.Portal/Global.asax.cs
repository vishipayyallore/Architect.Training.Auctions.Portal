using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Architect.Training.Auctions.Portal.Controllers;
using Architect.Training.Auctions.Portal.Data;
//using Architect.Training.Auctions.Portal.Infrastructure;
using Architect.Training.Auctions.Portal.Models;
using StructureMap;
using StructureMap.Graph;

namespace Architect.Training.Auctions.Portal
{
    public class MvcApplication : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }
    
    }
}
