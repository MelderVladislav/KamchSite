using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KamchatkaSite.Startup))]
namespace KamchatkaSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
