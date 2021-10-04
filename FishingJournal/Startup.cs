using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FishingJournal.Startup))]
namespace FishingJournal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
