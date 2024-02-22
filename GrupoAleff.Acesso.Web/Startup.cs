using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GrupoAleff.Acesso.Web.Startup))]
namespace GrupoAleff.Acesso.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
