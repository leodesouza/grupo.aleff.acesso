using AutoMapper;
using GrupoAleff.Acesso.API.Models;
using GrupoAleff.Acesso.AppService.Interfaces;
using GrupoAleff.Acesso.Domain.Entities;
using System;
using System.Collections.Generic;
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


        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var usuarios = await _usuarioAppService.GetAll();
                var usuarioModel = _mapper.Map<IEnumerable<UsuarioModel>>(usuarios);

                return Ok(usuarioModel);

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                var usuario = await _usuarioAppService.GetById(id);
                var usuarioModel = _mapper.Map<UsuarioModel>(usuario);

                return Ok(usuarioModel);

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
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
                return InternalServerError(ex);
            }
        }
        
        public async Task<IHttpActionResult> Put([FromBody] UsuarioModel model)
        {
            try
            {
                var usuarioSalvo = await _usuarioAppService.GetById(model.UsuarioId);                
                if (usuarioSalvo == null)
                    return BadRequest();
                
                var usuario = _mapper.Map<Usuario>(model);
                await _usuarioAppService.Update(usuario);

                return Ok();

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                var usuario = await _usuarioAppService.GetById(id);
                if (usuario == null)
                    return BadRequest();

                await _usuarioAppService.Remove(usuario);

                return Ok();

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}