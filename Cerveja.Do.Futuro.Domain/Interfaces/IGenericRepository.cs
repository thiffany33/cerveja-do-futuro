using System;
using System.Collections.Generic;
using System.Text;

namespace Cerveja.Do.Futuro.Domain.Interfaces
{
    public interface IGenericRepository<TEntity>
    {
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(Guid id);
    }
}
