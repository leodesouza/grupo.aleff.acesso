using GrupoAleff.Acesso.AppService.AppServices;
using GrupoAleff.Acesso.AppService.Interfaces;
using GrupoAleff.Acesso.Domain.Interfaces.Repository;
using GrupoAleff.Acesso.Infra.Data.Context;
using GrupoAleff.Acesso.Infra.Data.Repositories;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Lifestyles;
using System.Configuration;
using System.Reflection;
using System.Web.Mvc;


namespace GrupoAleff.Acesso.Web
{
    public class SimpleInjectorConfig
    {
        public static void RegisterDepedencies()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

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

            //Repository
            container.Register<IUsuarioRepository, UsuarioRepository>(Lifestyle.Scoped);
            container.Register<ILogAcessoRepository, LogAcessoRepository>(Lifestyle.Scoped);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();
            
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}