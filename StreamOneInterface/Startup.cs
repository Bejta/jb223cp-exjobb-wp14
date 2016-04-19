using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StreamOneInterface.Startup))]
namespace StreamOneInterface
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
