using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Geo.Startup))]
namespace Geo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
