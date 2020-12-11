using Cerveja.Do.Futuro.Domain.Entities;
using System.Collections.Generic;

namespace Cerveja.Do.Futuro.Domain.Interfaces.Validacao
{
    public interface ICervejariaValidacao
    {
        List<string> Validade(Cervejarias cervejarias);
    }
}
