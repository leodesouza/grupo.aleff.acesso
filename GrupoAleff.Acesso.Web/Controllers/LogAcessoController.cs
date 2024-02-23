using AutoMapper;
using GrupoAleff.Acesso.AppService.Interfaces;
using GrupoAleff.Acesso.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GrupoAleff.Acesso.Web.Controllers
{
    public class LogAcessoController : BaseController
    {
        private readonly ILogAcessoAppService _logAcessoAppService;        
        private readonly IMapper _mapper;
        public LogAcessoController(ILogAcessoAppService logAcessoAppService, IMapper mapper)
        {
            _logAcessoAppService = logAcessoAppService;            
            _mapper = mapper;
        }

        public async Task<ActionResult> Index()
        {
            try
            {
                var logAcessos = await _logAcessoAppService.ObterLogsAcesso();                

                var logAcessosViewModel = _mapper.Map<IEnumerable<LogAcessoViewModel>>(logAcessos);                

                return View(logAcessosViewModel);
            }
            catch (System.Exception)
            {

                return View();
            }
        }
    }
}
