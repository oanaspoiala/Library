using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task Add(TEntity entity);

        Task<ICollection<TEntity>> GetAllAsyn();

        Task<TEntity> GetById(Guid id);       

        Task Update(Guid id, TEntity entity);

        Task Delete(Guid id);
    }
}
