using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(loginentityF.Startup))]
namespace loginentityF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
