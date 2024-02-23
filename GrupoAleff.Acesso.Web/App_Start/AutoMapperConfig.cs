using AutoMapper;
using GrupoAleff.Acesso.Domain.Entities;
using GrupoAleff.Acesso.Web.Models;
using System.Collections.Generic;

namespace GrupoAleff.Acesso.Web
{
    public class AutoMapperConfig
    {       
        public static IMapper Register()
        {
            var config = new MapperConfiguration(cfg =>
            {
                
                cfg.CreateMap<UsuarioViewModel, Usuario>();
                cfg.CreateMap<Usuario, UsuarioViewModel>();
                cfg.CreateMap<List<Usuario>, List<UsuarioViewModel>>();

                //LogAcesso
                cfg.CreateMap<LogAcessoViewModel, LogAcesso>();
                cfg.CreateMap<LogAcesso, LogAcessoViewModel>();
                cfg.CreateMap<List<LogAcesso>, List<LogAcessoViewModel>>();
            });

            return config.CreateMapper();
        }
    }
}