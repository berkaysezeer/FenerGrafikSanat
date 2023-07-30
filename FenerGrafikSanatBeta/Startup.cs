using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FenerGrafikSanatBeta.Startup))]
namespace FenerGrafikSanatBeta
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
