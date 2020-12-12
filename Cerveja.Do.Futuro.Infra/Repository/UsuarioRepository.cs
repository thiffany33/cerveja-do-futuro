using Cerveja.Do.Futuro.Domain.Entities;
using Cerveja.Do.Futuro.Domain.Interfaces;
using Cerveja.Do.Futuro.Infra.Context;
using System.Linq;
using static Cerveja.Do.Futuro.Infra.Repository.GenericRepository.GenericRepository;

namespace Cerveja.Do.Futuro.Infra.Repository
{
    public class UsuarioRepository : GenericRepositorie<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(MainContext mainContext)
            : base(mainContext)
        {
        }

        public Usuario ObterUsuarioPorCPF(string cpf)
        {
            var usuario = Query().FirstOrDefault(q => q.Cpf == cpf);
            return usuario;
        }
    }
}
