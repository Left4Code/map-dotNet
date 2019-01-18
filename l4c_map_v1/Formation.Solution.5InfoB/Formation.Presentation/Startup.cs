using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Formation.Presentation.Startup))]
namespace Formation.Presentation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
