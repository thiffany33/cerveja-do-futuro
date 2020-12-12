using Cerveja.Do.Futuro.Aplication.Interfaces;
using Cerveja.Do.Futuro.Domain.Entities;
using Cerveja.Do.Futuro.Domain.Interfaces;
using Cerveja.Do.Futuro.Domain.Interfaces.Validacao;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cerveja.Do.Futuro.Aplication.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioValidacao _usuarioValidacao;

        public UsuarioService(IUsuarioRepository usuarioRepository, IUsuarioValidacao usuarioValidacao)
        {
            _usuarioRepository = usuarioRepository;
            _usuarioValidacao = usuarioValidacao;
        }

        public List<string> Cadastrar(Usuario usuario)
        {
            var erros = _usuarioValidacao.ValidarCadastro(usuario);
            if (erros.Count() == 0)
            {
                _usuarioRepository.Create(usuario);
            }
            return erros;
        }

        public List<string> Editar(Usuario usuario)
        {
            var erros = _usuarioValidacao.ValidarAtualizar(usuario);
            if (erros.Count() == 0)
            {
                _usuarioRepository.Update(usuario);
            }
            return erros;
        }

        public List<string> Deletar(Guid id)
        {
            var erros = _usuarioValidacao.ValidarDeletar(id);
            if (!erros.Any())
            {
                _usuarioRepository.Delete(id);
            }
            return erros;
        }
    }
}
