using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExerciseGO.Startup))]
namespace ExerciseGO
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
