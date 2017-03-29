using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AnimeDB.Startup))]
namespace AnimeDB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
