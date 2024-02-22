using AutoMapper;
using GrupoAleff.Acesso.AppService.Interfaces;
using GrupoAleff.Acesso.Domain.Entities;
using GrupoAleff.Acesso.Web.Models;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GrupoAleff.Acesso.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioAppService _usuarioAppService;
        private readonly IMapper _mapper;
        public UsuarioController(IUsuarioAppService usuarioAppService, IMapper mapper)
        {
            _usuarioAppService = usuarioAppService;
            _mapper = mapper;
        }
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public async Task<ActionResult> Cadastrar(UsuarioViewModel usuarioModel)
        {
            try
            {

                var usuario = _mapper.Map<Usuario>(usuarioModel);
                await _usuarioAppService.Add(usuario);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
