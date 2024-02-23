using GrupoAleff.Acesso.Web.Models;
using System.Web.Mvc;
using System.Web.Routing;

namespace GrupoAleff.Acesso.Web.Controllers
{
    public class BaseController : Controller
    {

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (!UsuarioAdmin)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Conta", action = "Login" }));                
            }
        }

        public bool UsuarioAdmin
        {
            get { 
                    if(Session["USUARIO_LOGADO"] == null)
                        Session["USUARIO_LOGADO"] = true;

                return (bool)Session["USUARIO_LOGADO"]; 
            }
            set
            {
                Session["USUARIO_LOGADO"] = value;
            }
        }

        public bool UsuarioLogado
        {
            get
            {
                if (Session["USUARIO_NORMAL"] == null)
                    Session["USUARIO_NORMAL"] = true;

                return (bool)Session["USUARIO_NORMAL"];
            }
            set
            {
                Session["USUARIO_NORMAL"] = value;
            }
        }

        public string NomeUsuarioLogado
        {
            get
            {
                if (Session["NOME_USUARIO"] == null)
                    Session["NOME_USUARIO"] = true;

                return Session["NOME_USUARIO"].ToString();
            }
            set
            {
                Session["NOME_USUARIO"] = value;
            }
        }        
    }
}