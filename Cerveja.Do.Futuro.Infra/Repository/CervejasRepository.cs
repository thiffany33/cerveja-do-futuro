using Cerveja.Do.Futuro.Domain.Entities;
using Cerveja.Do.Futuro.Domain.Interfaces;
using Cerveja.Do.Futuro.Infra.Context;
using static Cerveja.Do.Futuro.Infra.Repository.GenericRepository.GenericRepository;

namespace Cerveja.Do.Futuro.Infra.Repository
{
    public class CervejasRepository : GenericRepositorie<Cervejas>, ICervejasRepository
    {
        public CervejasRepository(MainContext mainContext)
            : base(mainContext)
        {
        }
    }
}
