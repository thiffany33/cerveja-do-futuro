﻿using Cerveja.Do.Futuro.Infra.Repository.GenericRepository;
using Cerveja.Do.Futuro.Domain.Interfaces;
using Cerveja.Do.Futuro.Domain.Entities;
using Cerveja.Do.Futuro.Infra.Context;
using System.Linq;
using static Cerveja.Do.Futuro.Infra.Repository.GenericRepository.GenericRepository;

namespace Cerveja.Do.Futuro.Infra.Repository
{
    public class CervejariaRepository : GenericRepositorie<Cervejarias>, ICervejariaRepository
    {
        public CervejariaRepository(MainContext mainContext)
            : base(mainContext)
        {
        }

        public Cervejarias ObterCervejariasPorCNPJ(string cpnj)
        {
            var cervejarias = Query().FirstOrDefault(q => q.Cnpj == cpnj);
            return cervejarias;
        }
    }
}
