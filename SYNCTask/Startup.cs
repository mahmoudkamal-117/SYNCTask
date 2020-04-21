using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SYNCTask.Startup))]
namespace SYNCTask
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
