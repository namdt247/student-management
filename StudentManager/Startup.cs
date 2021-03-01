using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudentManager.Startup))]
namespace StudentManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
