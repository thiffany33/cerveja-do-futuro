using Cerveja.Do.Futuro.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Cerveja.Do.Futuro.Aplication.Interfaces
{
    public interface IUsuarioService
    {
        List<string> Cadastrar(Usuario usuario);
        List<string> Editar(Usuario usuario);
        List<string> Deletar(Guid id);
    }
}
