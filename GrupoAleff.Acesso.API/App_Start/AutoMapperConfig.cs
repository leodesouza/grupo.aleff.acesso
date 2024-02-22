using AutoMapper;
using GrupoAleff.Acesso.API.Models;
using GrupoAleff.Acesso.Domain.Entities;
using System.Collections.Generic;

namespace GrupoAleff.Acesso.API.App_Start
{
    public class AutoMapperConfig
    {       
        public static IMapper Register()
        {
            var config = new MapperConfiguration(cfg =>
            {
                //Usuario
                cfg.CreateMap<UsuarioModel, Usuario>();
                cfg.CreateMap<Usuario, UsuarioModel>();
                cfg.CreateMap<List<Usuario>, List<UsuarioModel>>();

                //LogAcesso
                cfg.CreateMap<LogAcessoModel, LogAcesso>();
                cfg.CreateMap<LogAcesso, LogAcessoModel>();
                cfg.CreateMap<List<LogAcesso>, List<LogAcessoModel>>();
            });

            return config.CreateMapper();
        }
    }
}