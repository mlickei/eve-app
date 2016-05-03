using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EveOnlineMissioningApp.Startup))]
namespace EveOnlineMissioningApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
