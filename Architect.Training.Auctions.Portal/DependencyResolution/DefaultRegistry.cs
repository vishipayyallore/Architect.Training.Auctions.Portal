// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using Architect.Training.Auctions.Portal.App_Start;
using Architect.Training.Auctions.Portal.Controllers;
using Architect.Training.Auctions.Portal.Data;
using Architect.Training.Auctions.Portal.Models;
using StructureMap.TypeRules;

namespace Architect.Training.Auctions.Portal.DependencyResolution {
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
	
    public class DefaultRegistry : Registry {
        #region Constructors and Destructors

        public DefaultRegistry() {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                    scan.TheCallingAssembly();
					scan.With(new ControllerConvention());

                    //Additional refernces for the application to start with ...
                    For<Microsoft.AspNet.Identity.IUserStore<ApplicationUser>>().Use<Microsoft.AspNet.Identity.EntityFramework.UserStore<ApplicationUser>>();
                    For<System.Data.Entity.DbContext>().Use(() => new ApplicationDbContext());
                    For<Microsoft.Owin.Security.IAuthenticationManager>().Use(() => HttpContext.Current.GetOwinContext().Authentication);
                    
                    //Gives us the current logged in user.
                    For<IIdentity>().Use(() => HttpContext.Current.User.Identity);
                    
                    //For Action Filters
                    For<IFilterProvider>().Use(new AuctionsFilterProvider(() => StructuremapMvc.StructureMapDependencyScope.Container));
                    //Setting the Properties of Action Filter
                    Policies.SetAllProperties(x =>
                        x.Matching(p =>
                                    p.DeclaringType.CanBeCastTo(typeof(ActionFilterAttribute)) &&
                                    p.DeclaringType.Namespace.StartsWith("Architect.Training.Auctions.Portal") &&
                                    !p.PropertyType.IsPrimitive &&
                                    p.PropertyType != typeof(string)));
                });
        
        }

        #endregion
    }
}