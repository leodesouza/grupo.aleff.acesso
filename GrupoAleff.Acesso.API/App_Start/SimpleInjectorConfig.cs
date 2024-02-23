using AutoMapper;
using GrupoAleff.Acesso.AppService.AppServices;
using GrupoAleff.Acesso.AppService.Interfaces;
using GrupoAleff.Acesso.Domain.Interfaces.Repository;
using GrupoAleff.Acesso.Infra.Data.Context;
using GrupoAleff.Acesso.Infra.Data.Repositories;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Configuration;
using System.Web.Http;

namespace GrupoAleff.Acesso.API.App_Start
{
    public class SimpleInjectorConfig
    {
        public static void RegisterDepedencies()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            container.Register(() =>            
                AutoMapperConfig.Register(), Lifestyle.Singleton
            );

            //Dados
            container.Register<IAleffDBContext>(() =>
            {
                string connectionString = ConfigurationManager.ConnectionStrings["AleffBD"].ConnectionString;
                return new AleffDBContext(connectionString);

            }, Lifestyle.Singleton);

            //AppService
            container.Register<IUsuarioAppService, UsuarioAppService>(Lifestyle.Scoped);
            container.Register<ILogAcessoAppService, LogAcessoAppService>(Lifestyle.Scoped);

            //Repository
            container.Register<IUsuarioRepository, UsuarioRepository>(Lifestyle.Scoped);
            container.Register<ILogAcessoRepository, LogAcessoRepository>(Lifestyle.Scoped);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}