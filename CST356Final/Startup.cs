using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CST356Final.Startup))]
namespace CST356Final
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
