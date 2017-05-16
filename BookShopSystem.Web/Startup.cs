using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(BookShopSystem.Web.Startup))]

namespace BookShopSystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
