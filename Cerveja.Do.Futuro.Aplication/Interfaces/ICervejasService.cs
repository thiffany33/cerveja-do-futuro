using Cerveja.Do.Futuro.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Cerveja.Do.Futuro.Aplication.Interfaces
{
    public interface ICervejasService
    {
        public List<string> Cadastrar(Cervejas cervejas);
        public List<string> Deletar(Guid id);
        List<string> Editar(Cervejas cervejas);
        IEnumerable<Cervejas> ListarTodos();
    }
}
