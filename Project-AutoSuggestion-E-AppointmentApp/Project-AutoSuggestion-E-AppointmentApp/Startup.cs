using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Project_AutoSuggestion_E_AppointmentApp.Startup))]
namespace Project_AutoSuggestion_E_AppointmentApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
