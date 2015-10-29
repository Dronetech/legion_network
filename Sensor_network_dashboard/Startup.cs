using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sensor_network_dashboard.Startup))]
namespace Sensor_network_dashboard
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
