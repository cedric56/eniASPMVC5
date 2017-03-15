using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ToDoExemple.Startup))]
namespace ToDoExemple
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
