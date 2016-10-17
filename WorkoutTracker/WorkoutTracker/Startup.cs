using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WorkoutTracker.Startup))]
namespace WorkoutTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
