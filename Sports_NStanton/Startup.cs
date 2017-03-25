using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sports_NStanton.Startup))]
namespace Sports_NStanton
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
