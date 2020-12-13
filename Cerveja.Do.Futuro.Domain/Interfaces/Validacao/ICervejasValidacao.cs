using Cerveja.Do.Futuro.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Cerveja.Do.Futuro.Domain.Interfaces.Validacao
{
    public interface ICervejasValidacao
    {
        List<string> ValidarEditar(Cervejas cervejas);
        List<string> ValidarDeletar(Guid id);
        List<string> ValidarCadastro(Cervejas cervejas);
    }
}
