using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StructureMap;
using StructureMap.Configuration.DSL;
using StructureMap.TypeRules;

namespace Architect.Training.Auctions.Portal.DependencyResolution
{

    public class ActionFilterRegistry : Registry
    {

        public ActionFilterRegistry(Func<IContainer> containerFactory)
        {
            //For Action Filters
            For<IFilterProvider>().Use(new AuctionsFilterProvider(containerFactory));
            
            //Setting the Properties of Action Filter
            Policies.SetAllProperties(x =>
                x.Matching(p =>
                            p.DeclaringType.CanBeCastTo(typeof(ActionFilterAttribute)) &&
                            p.DeclaringType.Namespace.StartsWith("Architect.Training.Auctions.Portal") &&
                            !p.PropertyType.IsPrimitive &&
                            p.PropertyType != typeof(string)));
        }

    }

}