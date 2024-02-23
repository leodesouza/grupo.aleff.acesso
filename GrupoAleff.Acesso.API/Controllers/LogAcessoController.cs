using GrupoAleff.Acesso.API.Models;
using GrupoAleff.Acesso.AppService.AppServices;
using GrupoAleff.Acesso.AppService.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Web.Http;
using AutoMapper;

namespace GrupoAleff.Acesso.API.Controllers
{
    public class LogAcessoController : ApiController
    {
        private readonly ILogAcessoAppService _logAcessoAppService;
        private readonly IMapper _mapper;
        public LogAcessoController(ILogAcessoAppService logAcessoAppService, IMapper mapper)
        {
            _logAcessoAppService = logAcessoAppService;
            _mapper = mapper;
        }

    
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                var acessos = await _logAcessoAppService.ObterLogsAcesso(id);
                var acessosModel = _mapper.Map<IEnumerable<LogAcessoModel>>(acessos);

                return Ok(acessosModel);

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}