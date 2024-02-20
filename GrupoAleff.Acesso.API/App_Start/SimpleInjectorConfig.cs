using GrupoAleff.Acesso.AppService.AppServices;
using GrupoAleff.Acesso.AppService.Interfaces;
using GrupoAleff.Acesso.Domain.Interfaces.Repository;
using GrupoAleff.Acesso.Infra.Data.Repositories;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Web.Http;
using System.Web.Mvc;

namespace GrupoAleff.Acesso.API.App_Start
{
    public class SimpleInjectorConfig
    {
        public static void RegisterDepedencies()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            //AppService
            container.Register<IUsuarioAppService, UsuarioAppService>(Lifestyle.Scoped);

            //Repository
            container.Register<IUsuarioRepository, UsuarioRepository>(Lifestyle.Scoped);
            container.Register<ILogAcessoRepository, LogAcessoRepository>(Lifestyle.Scoped);
                        
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);                                    
        }
    }
}