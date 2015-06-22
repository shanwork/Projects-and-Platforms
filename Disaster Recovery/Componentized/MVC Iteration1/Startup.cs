using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Iteration1.Startup))]
namespace MVC_Iteration1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
