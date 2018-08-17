using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MagicNeinBall.Startup))]
namespace MagicNeinBall
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //    ConfigureAuth(app);
        }
    }
}
