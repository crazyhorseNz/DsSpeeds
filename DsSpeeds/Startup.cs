using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DsSpeeds.Startup))]
namespace DsSpeeds
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
