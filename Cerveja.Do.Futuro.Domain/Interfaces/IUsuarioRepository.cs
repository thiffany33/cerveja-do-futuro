using Cerveja.Do.Futuro.Domain.Entities;

namespace Cerveja.Do.Futuro.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario ObterUsuarioPorCPF(string cpf);
    }
}
