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
        public ActionResult Cadastrar(Usuario produto)
        {
            var erros = _usuarioService.Cadastrar(produto);
            if (erros.Any())
            {
                return BadRequest(erros);
            }
            return Ok("Adicionado com Sucesso");
        }

        [HttpPut]
        [Route("EditarCadastro")]
        public ActionResult Editar(Usuario produto)
        {
            var erros = _usuarioService.Editar(produto);
            if (erros.Any())
            {
                return BadRequest(erros);
            }
            return Ok("Seu Cadastro foi autalizado com Sucesso!");
        }

        [HttpDelete]
        [Route("DeletarCadastro")]
        public ActionResult Deletar(Guid Id)
        {
            var erros = _usuarioService.Deletar(Id);
            if (erros.Any())
            {
                return BadRequest(erros);
            }
            return Ok("Usuario Deletado com Sucesso");
        }
    }
}
