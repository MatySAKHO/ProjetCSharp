using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjetCSharp.Startup))]
namespace ProjetCSharp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
