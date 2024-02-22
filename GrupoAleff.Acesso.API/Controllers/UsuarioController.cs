using AutoMapper;
using GrupoAleff.Acesso.API.Models;
using GrupoAleff.Acesso.AppService.Interfaces;
using GrupoAleff.Acesso.Domain.Entities;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace GrupoAleff.Acesso.API.Controllers
{
    public class UsuarioController : ApiController
    {
        private readonly IUsuarioAppService _usuarioAppService;
        private readonly IMapper _mapper;
        public UsuarioController(IUsuarioAppService usuarioAppService, IMapper mapper)
        {
            _usuarioAppService = usuarioAppService;
            _mapper = mapper;
        }


        public async Task<UsuarioModel> Get()
        {
            return await Task.Run(() =>
            {
                var model = new UsuarioModel();
                return model;
            });
        }

        public string Get(int id)
        {
            return "value";
        }

        public async Task<IHttpActionResult> Post([FromBody] UsuarioModel model)
        {
            try
            {
                var usuario = _mapper.Map<Usuario>(model);
                await _usuarioAppService.Add(usuario);

                return Ok();

            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

    }
}