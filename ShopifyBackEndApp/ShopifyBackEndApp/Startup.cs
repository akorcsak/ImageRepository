using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShopifyBackEndApp.Startup))]
namespace ShopifyBackEndApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
