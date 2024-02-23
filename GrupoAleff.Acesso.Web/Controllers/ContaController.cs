using AutoMapper;
using GrupoAleff.Acesso.AppService.Interfaces;
using GrupoAleff.Acesso.Domain.Entities;
using GrupoAleff.Acesso.Web.Models;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GrupoAleff.Acesso.Web.Controllers
{
    public class ContaController : Controller
    {
        private readonly IUsuarioAppService _usuarioAppService;
        private readonly ILogAcessoAppService _logAcessoAppService;
        private readonly IMapper _mapper;
        public ContaController(IUsuarioAppService usuarioAppService, ILogAcessoAppService logAcessoAppService, 
            IMapper mapper)
        {
            _usuarioAppService = usuarioAppService;
            _logAcessoAppService = logAcessoAppService;
            _mapper = mapper;
        }
        // GET: Conta
        public ActionResult Login()
        {            
            return View();            
        }
        public ActionResult LogOff()
        {
            Session["USUARIO_NORMAL"] = false;
            Session["USUARIO_LOGADO"] = false;
            Session["NOME_USUARIO"] = "";
            return Redirect("~/Home/Index");            
        }        
        public async Task<ActionResult> LoginUsuario(LoginViewModel loginViewModel)
        {
            try
            {
                var usuario = await _usuarioAppService.ObterUsuario(loginViewModel.Login, loginViewModel.Senha);
                if (usuario != null) {
                    TempData["ErrorMessage"] = "";                    
                    Session["USUARIO_LOGADO"] = usuario.IsAdmin == 1;
                    Session["USUARIO_NORMAL"] = true;
                    Session["NOME_USUARIO"] = usuario.Nome;

                    var logAcesso = _mapper.Map<LogAcesso>(new LogAcessoViewModel()
                    {
                        UsuarioId = usuario.UsuarioId,                        
                        EnderecoIp = HttpContext.Request.UserHostAddress
                    });

                    await _logAcessoAppService.InserirLogAcesso(logAcesso);

                    return Redirect("~/LogAcesso/Index");
                }
                else
                {
                    TempData["ErrorMessage"] = "Usuario ou senha inválidos";
                    return RedirectToAction("Login");
                }                                                
            }
            catch(Exception ex)
            {
                return RedirectToAction("Login");
            }
            
        }


    }
}