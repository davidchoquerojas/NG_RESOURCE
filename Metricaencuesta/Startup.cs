using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Metricaencuesta.Startup))]

namespace Metricaencuesta
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
