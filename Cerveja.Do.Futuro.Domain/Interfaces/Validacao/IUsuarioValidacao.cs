using Cerveja.Do.Futuro.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Cerveja.Do.Futuro.Domain.Interfaces.Validacao
{
    public interface IUsuarioValidacao
    {
        List<string> ValidarCadastro(Usuario usuario);
        List<string> ValidarDeletar(Guid id);
        List<string> ValidarAtualizar(Usuario produto);
    }
}
