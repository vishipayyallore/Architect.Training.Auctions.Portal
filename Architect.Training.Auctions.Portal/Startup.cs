using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Architect.Training.Auctions.Portal.Startup))]
namespace Architect.Training.Auctions.Portal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
