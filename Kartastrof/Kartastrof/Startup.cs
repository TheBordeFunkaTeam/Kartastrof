using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Kartastrof.Startup))]
namespace Kartastrof
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
