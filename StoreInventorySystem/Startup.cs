using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StoreInventorySystem.Startup))]
namespace StoreInventorySystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
