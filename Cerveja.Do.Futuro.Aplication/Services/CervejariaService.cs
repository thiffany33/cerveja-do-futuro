using Cerveja.Do.Futuro.Aplication.Interfaces;
using Cerveja.Do.Futuro.Domain.Entities;
using Cerveja.Do.Futuro.Domain.Interfaces;
using Cerveja.Do.Futuro.Domain.Interfaces.Validacao;
using System.Collections.Generic;
using System.Linq;

namespace Cerveja.Do.Futuro.Aplication.Services
{
    public class CervejariaService : ICervejariaService
    {
        private readonly ICervejariaRepository _cervejariaRepository;
        private readonly ICervejariaValidacao _cervjariaValidacao;
        public CervejariaService(ICervejariaRepository cervejariaRepository, ICervejariaValidacao cervejariaValidacao)
        {
            _cervejariaRepository = cervejariaRepository;
            _cervjariaValidacao = cervejariaValidacao;
        }

        public List<string> Cadastrar(Cervejarias cervejarias)
        {
            var erros = _cervjariaValidacao.Validade(cervejarias);
            if (erros.Count() == 0)
            {
                _cervejariaRepository.Create(cervejarias);
            }
            return erros;
        }
    }
}
