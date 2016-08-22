using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CashLady.Mvc.WebApp.Startup))]
namespace CashLady.Mvc.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
