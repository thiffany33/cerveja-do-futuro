using Cerveja.Do.Futuro.Aplication.Interfaces;
using Cerveja.Do.Futuro.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Cerveja.Do.Futuro.API.Controllers
{
    [ApiController]
    [Route("CadastroCervejas")]
    public class CervejasController : ControllerBase
    {
        private readonly ICervejasService _cervejasService;

        public CervejasController(ICervejasService cervejasService)
        {
            _cervejasService = cervejasService;
        }

        [HttpPost]
        [Route("Cadastrar")]
        public ActionResult Cadastrar(Cervejas cervejas)
        {
            var erros = _cervejasService.Cadastrar(cervejas);
            if (erros.Any())
            {
                return BadRequest(erros);
            }
            return Ok("Cadastrado com Sucesso");
        }

        [HttpDelete]
        [Route("Deletar")]
        public ActionResult Deletar(Guid id)
        {
            var erros = _cervejasService.Deletar(id);
            if (erros.Any())
            {
                return BadRequest(erros);
            }
            return Ok("Apagado com Sucesso");
        }

        [HttpPut]
        [Route("Editar")]
        public ActionResult Editar(Cervejas cervejas)
        {
            var erros = _cervejasService.Editar(cervejas);
            if (erros.Any())
            {
                return BadRequest(erros);
            }
            return Ok("Atualizado com Sucesso");
        }

        [HttpGet]
        [Route("ListarTodos")]
        public ActionResult ListarTodos()
        {
            return Ok(_cervejasService.ListarTodos());
        }
    }
}
