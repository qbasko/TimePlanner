using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TimePlanner.Startup))]
namespace TimePlanner
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
