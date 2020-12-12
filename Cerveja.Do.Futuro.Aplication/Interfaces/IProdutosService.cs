using Cerveja.Do.Futuro.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Cerveja.Do.Futuro.Aplication.Interfaces
{
    public interface IProdutosService
    {
        List<string> Cadastrar(Produtos produto);
        List<string> Deletar(Guid id);
        List<string> Atualizar(Produtos produto);
        public Produtos PesquisarPorId(Guid id);
        IEnumerable<Produtos> ListarTodos();
    }
}
