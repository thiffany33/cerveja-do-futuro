using Cerveja.Do.Futuro.Domain.Entities;
using Cerveja.Do.Futuro.Domain.Interfaces;
using Cerveja.Do.Futuro.Domain.Interfaces.Validacao;
using System;
using System.Collections.Generic;

namespace Cerveja.Do.Futuro.Domain.Validation
{
    public class CervejasValidacao : ICervejasValidacao
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ICervejasRepository _cervejasRepository;

        public CervejasValidacao(IUsuarioRepository usuarioRepository, ICervejasRepository cervejasRepository)
        {
            _usuarioRepository = usuarioRepository;
            _cervejasRepository = cervejasRepository;
        }

        public List<string> ValidarCadastro(Cervejas cervejas)
        {
            var listaErros = new List<string>();

            if (!ValidarNome(cervejas.Nome))
            {
                listaErros.Add("Nome não pode ficar em Branco!");
            }

            if (!ValidarPreco(cervejas.Preco))
            {
                listaErros.Add("Preco não pode ser menor que zero");
            }

            if (!ValidarValidade(cervejas.Validade))
            {
                listaErros.Add("A data tem que ser maior que a data atual");
            }

            if (!ValidarUsuario(cervejas.UsuarioId))
            {
                listaErros.Add("Esse Usuario não existe");
            }
            return listaErros;
        }

        public List<string> ValidarDeletar(Guid id)
        {
            var listaErros = new List<string>();
            if (_usuarioRepository.GetById(id) == null)
            {
                listaErros.Add("Id Inválido!");
            }
            return listaErros;
        }

        public List<string> ValidarEditar(Cervejas cervejas)
        {
            var listaErros = ValidarCadastro(cervejas);
            if (_usuarioRepository.GetById(cervejas.Id) == null)
            {
                listaErros.Add("Id não Encontrado!");
            }
            return listaErros;
        }

        private bool ValidarNome(string nome) => !string.IsNullOrWhiteSpace(nome);
        private bool ValidarPreco(double preco) => preco > 0;
        private bool ValidarValidade(DateTime validade) => (validade > DateTime.Now.Date);
        private bool ValidarUsuario(Guid id) => _usuarioRepository.GetById(id) != null;
    }
}
