using Cerveja.Do.Futuro.Domain.Entities;
using Cerveja.Do.Futuro.Domain.Interfaces;
using Cerveja.Do.Futuro.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static Cerveja.Do.Futuro.Infra.Repository.GenericRepository.GenericRepository;

namespace Cerveja.Do.Futuro.Infra.Repository
{
    public class ProdutoRepository : GenericRepositorie<Produtos>, IProdutoRepository
    {
        public ProdutoRepository(MainContext mainContext)
            : base(mainContext)
        {
        }

        public override IEnumerable<Produtos> GetAll()
        {
            return Query().Include(produto => produto.Cervejarias);
        }
    }
}
