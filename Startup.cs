using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ShelterAPI.StartupOwin))]

namespace ShelterAPI
{
    public partial class StartupOwin
    {
        public void Configuration(IAppBuilder app)
        {
            //AuthStartup.ConfigureAuth(app);
        }
    }
}
