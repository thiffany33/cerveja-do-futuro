﻿using Cerveja.Do.Futuro.Aplication.Interfaces;
using Cerveja.Do.Futuro.Domain.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Cerveja.Do.Futuro.API.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("Cadastro de Cervejarias")]
    public class CervejariaController : ControllerBase
    {
        private readonly ICervejariaService _cervejariaService;

        public CervejariaController(ICervejariaService cervejariaService)
        {
            _cervejariaService = cervejariaService;
        }

        [HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("Cadastrar")]
        public ActionResult Cadastrar(Cervejarias cervejarias)
        {
            var erros = _cervejariaService.Cadastrar(cervejarias);
            if (erros.Count() > 0)
            {
                return BadRequest(erros);
            }
            return Ok("Adicionado com Sucesso");
        }
    }
}
