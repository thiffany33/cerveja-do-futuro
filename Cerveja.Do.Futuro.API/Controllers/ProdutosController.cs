using Cerveja.Do.Futuro.Aplication.Interfaces;
using Cerveja.Do.Futuro.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Cerveja.Do.Futuro.API.Controllers
{
    [ApiController]
    [Route("CadastroCervejas")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutosService _produtosService;

        public ProdutosController(IProdutosService produtosService)
        {
            _produtosService = produtosService;
        }

        [HttpPost]
        [Route("Cadastrar")]
        public ActionResult Cadastrar(Produtos produtos)
        {
            var erros = _produtosService.Cadastrar(produtos);

            if (erros.Any())
            {
                return BadRequest(erros);
            }
            return Ok("Cerveja Cadastrada com Sucesso");
        }

        [HttpDelete]
        [Route("Deletar")]
        public ActionResult Deletar(Guid Id)
        {
            var erros = _produtosService.Deletar(Id);
            if (erros.Any())
            {
                return BadRequest(erros);
            }
            return Ok("Cerveja Apagado com Sucesso");
        }

        [HttpPut]
        [Route("Atualizar")]
        public ActionResult Atualizar(Produtos produto)
        {
            var erros = _produtosService.Atualizar(produto);
            if (erros.Any())
            {
                return BadRequest(erros);
            }
            return Ok("Cerveja atualizada com Sucesso!");
        }

        [HttpGet]
        [Route("Listar")]
        public ActionResult ListarTodos()
        {
            return Ok(_produtosService.ListarTodos());
        }
    }
}
