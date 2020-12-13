using Cerveja.Do.Futuro.Aplication.Interfaces;
using Cerveja.Do.Futuro.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Cerveja.Do.Futuro.API.Controllers
{
    [ApiController]
    [Route("CadastroUsuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        [Route("Cadastrar")]
        public ActionResult Cadastrar(Usuario usuario)
        {
            var erros = _usuarioService.Cadastrar(usuario);
            if (erros.Count() > 0)
            {
                return BadRequest(erros);
            }
            return Ok("Cadastrado com Sucesso");
        }

        [HttpPut]
        [Route("EditarCadastro")]
        public ActionResult Editar(Usuario usuario)
        {
            var erros = _usuarioService.Editar(usuario);
            if (erros.Count() > 0)
            {
                return BadRequest(erros);
            }
            return Ok("Atualizado com Sucesso!");
        }

        [HttpDelete]
        [Route("DeletarCadastro")]
        public ActionResult Deletar(Guid id)
        {
            var erros = _usuarioService.Deletar(id);
            if (erros.Count() > 0)
            {
                return BadRequest(erros);
            }
            return Ok("Apagado com Sucesso!");
        }
    }
}
