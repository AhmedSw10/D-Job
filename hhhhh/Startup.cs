using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(hhhhh.Startup))]
namespace hhhhh
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
