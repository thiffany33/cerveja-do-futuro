using Cerveja.Do.Futuro.Aplication.Interfaces;
using Cerveja.Do.Futuro.Domain.Entities;
using Cerveja.Do.Futuro.Domain.Interfaces;
using Cerveja.Do.Futuro.Domain.Interfaces.Validacao;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cerveja.Do.Futuro.Aplication.Services
{
    public class CervejasService : ICervejasService
    {
        private readonly ICervejasRepository _cervejasRepository;
        private readonly ICervejasValidacao _cervejasValidacao;

        public CervejasService(ICervejasRepository cervejasRepository, ICervejasValidacao cervejasValidacao)
        {
            _cervejasRepository = cervejasRepository;
            _cervejasValidacao = cervejasValidacao;
        }

        public List<string> Cadastrar(Cervejas cervejas)
        {
            var erros = _cervejasValidacao.ValidarCadastro(cervejas);
            if (!erros.Any())
            {
                _cervejasRepository.Create(cervejas);
            }
            return erros;
        }

        public List<string> Deletar(Guid id)
        {
            var erros = _cervejasValidacao.ValidarDeletar(id);
            if (!erros.Any())
            {
                _cervejasRepository.Delete(id);
            }
            return erros;
        }

        public List<string> Editar(Cervejas cervejas)
        {
            var erros = _cervejasValidacao.ValidarEditar(cervejas);
            if (!erros.Any())
            {
                _cervejasRepository.Update(cervejas);
            }
            return erros;
        }

        public IEnumerable<Cervejas> ListarTodos()
        {
            return _cervejasRepository.GetAll();
        }
    }
}
