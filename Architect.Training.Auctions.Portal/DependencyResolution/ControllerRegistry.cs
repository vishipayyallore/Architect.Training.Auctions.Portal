using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace Architect.Training.Auctions.Portal.DependencyResolution
{
    public class ControllerRegistry : Registry
    {

        public ControllerRegistry()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.With(new ControllerConvention());
            });
        }
    }
}