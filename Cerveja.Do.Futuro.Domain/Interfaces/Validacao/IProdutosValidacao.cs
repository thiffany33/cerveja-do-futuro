using Cerveja.Do.Futuro.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Cerveja.Do.Futuro.Domain.Interfaces.Validacao
{
    public interface IProdutosValidacao
    {
        List<string> ValidarCadastro(Produtos produto);
        List<string> ValidarDeletar(Guid id);
        List<string> ValidarAtualizar(Produtos produto);
    }
}
