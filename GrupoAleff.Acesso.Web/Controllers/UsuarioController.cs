using AutoMapper;
using GrupoAleff.Acesso.AppService.Interfaces;
using GrupoAleff.Acesso.Domain.Entities;
using GrupoAleff.Acesso.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GrupoAleff.Acesso.Web.Controllers
{
    public class UsuarioController : BaseController
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
              
        
        public ActionResult CadastrarUsuario()
        {
            return View();
        }


        public async Task<ActionResult> ListarUsuarios()
        {
            try
            {
                var usuarios = await _usuarioAppService.GetAll();
                var usuarioModel = _mapper.Map<IEnumerable<UsuarioViewModel>>(usuarios);
                return View(usuarioModel);
            }
            catch (System.Exception)
            {

                return View();
            }

        }

        public async Task<ActionResult> EditarUsuario(int id)
        {
            try
            {
                var usuario = await _usuarioAppService.GetById(id);
                if (usuario != null)
                {
                    var usuarioModel = _mapper.Map<UsuarioViewModel>(usuario);
                    return View(usuarioModel);
                }

                return View();
            }
            catch (System.Exception)
            {

                return View();
            }
        }

        public async Task<ActionResult> SalvarUsuario(UsuarioViewModel usuarioViewModel)
        {
            try
            {
                var usuarioSalvo = await _usuarioAppService.GetById(usuarioViewModel.UsuarioId);
                if (usuarioSalvo != null)
                {
                    var usuario = _mapper.Map<Usuario>(usuarioViewModel);
                    await _usuarioAppService.Update(usuario);                    
                }
                return RedirectToAction("ListarUsuarios");
            }
            catch (System.Exception)
            {

                return View();
            }
        }

        

        public async Task<ActionResult> DeletarUsuario(int id)
        {
            try
            {
                var usuarioSalvo = await _usuarioAppService.GetById(id);
                if (usuarioSalvo != null)                
                    await _usuarioAppService.Remove(usuarioSalvo);
                
                return RedirectToAction("ListarUsuarios");
            }
            catch (System.Exception)
            {

                return View();
            }

        }


        // POST: Usuario/Create
        [HttpPost]
        public async Task<ActionResult> Cadastrar(UsuarioViewModel usuarioModel)
        {
            try
            {

                var usuario = _mapper.Map<Usuario>(usuarioModel);
                await _usuarioAppService.Add(usuario);
                
                return RedirectToAction("ListarUsuarios");
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
