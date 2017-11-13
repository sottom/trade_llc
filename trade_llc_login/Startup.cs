using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(trade_llc_login.Startup))]
namespace trade_llc_login
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
