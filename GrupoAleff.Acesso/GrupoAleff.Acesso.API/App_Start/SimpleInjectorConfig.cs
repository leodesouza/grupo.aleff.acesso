using GrupoAleff.Acesso.AppService.AppServices;
using GrupoAleff.Acesso.AppService.Interfaces;
using GrupoAleff.Acesso.Domain.Interfaces.Repository;
using GrupoAleff.Acesso.Infra.Data.Repositories;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Reflection;
using System.Web.Mvc;

namespace GrupoAleff.Acesso.API.App_Start
{
    public class SimpleInjectorConfig
    {
        public static void RegisterDepedencies()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            //AppService
            container.Register<IUsuarioAppService, UsuarioAppService>();

            //Repository
            container.Register<IUsuarioRepository, UsuarioRepository>();
            container.Register<ILogAcessoRepository, LogAcessoRepository>();

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

        }
    }
}