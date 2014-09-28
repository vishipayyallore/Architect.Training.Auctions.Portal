using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using Architect.Training.Auctions.Portal.Data;
using Architect.Training.Auctions.Portal.Models;
using StructureMap.Configuration.DSL;

namespace Architect.Training.Auctions.Portal.DependencyResolution
{

    public class MvcRegistry : Registry
    {
        public MvcRegistry()
        {
            For<BundleCollection>().Use(BundleTable.Bundles);
            For<RouteCollection>().Use(RouteTable.Routes);
            For<IIdentity>().Use(() => HttpContext.Current.User.Identity);
            For<HttpSessionStateBase>().Use(() => new HttpSessionStateWrapper(HttpContext.Current.Session));
            For<HttpContextBase>().Use(() => new HttpContextWrapper(HttpContext.Current));
            For<HttpServerUtilityBase>().Use(() => new HttpServerUtilityWrapper(HttpContext.Current.Server));
            For<Microsoft.AspNet.Identity.IUserStore<ApplicationUser>>().Use<Microsoft.AspNet.Identity.EntityFramework.UserStore<ApplicationUser>>();
            For<System.Data.Entity.DbContext>().Use(() => new ApplicationDbContext());
            For<Microsoft.Owin.Security.IAuthenticationManager>().Use(() => HttpContext.Current.GetOwinContext().Authentication);
        }
    }

}