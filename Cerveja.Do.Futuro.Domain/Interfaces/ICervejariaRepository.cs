using Cerveja.Do.Futuro.Domain.Entities;

namespace Cerveja.Do.Futuro.Domain.Interfaces
{
    public interface ICervejariaRepository : IGenericRepository<Cervejarias>
    {
        Cervejarias ObterCervejariasPorCNPJ(string cpnj);
    }
}
