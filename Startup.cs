using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PageCMS2.Startup))]
namespace PageCMS2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
