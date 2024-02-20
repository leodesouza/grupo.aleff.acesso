using GrupoAleff.Acesso.API.Models;
using GrupoAleff.Acesso.AppService.Interfaces;
using System.Collections.Generic;
using System.Web.Http;

namespace GrupoAleff.Acesso.API.Controllers
{
    public class UsuarioController : ApiController
    {
        private readonly IUsuarioAppService _usuarioAppService;
        public UsuarioController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] UsuarioModel value)
        {
            //_usuarioAppService.Add
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