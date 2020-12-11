using Cerveja.Do.Futuro.Domain.Entities;
using System.Collections.Generic;

namespace Cerveja.Do.Futuro.Aplication.Interfaces
{
    public interface ICervejariaService
    {
        List<string> Cadastrar(Cervejarias cervejarias);
    }
}
