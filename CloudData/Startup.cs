using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CloudData.Startup))]
namespace CloudData
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
