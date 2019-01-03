using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ValueChain.Startup))]
namespace ValueChain
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
