using AutoMapper;
using GrupoAleff.Acesso.API.Models;
using GrupoAleff.Acesso.Domain.Entities;

namespace GrupoAleff.Acesso.API.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(config =>
            {
                //Usuario
                config.CreateMap<UsuarioModel, Usuario>();
                config.CreateMap<Usuario, UsuarioModel>();

                //LogAcesso
                config.CreateMap<LogAcessoModel, LogAcesso>();
                config.CreateMap<LogAcesso, LogAcessoModel>();
            });
        }
    }
}