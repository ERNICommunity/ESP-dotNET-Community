using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarColors.Data.Repositories
{
    public interface IRepository<TEntity, TKey> where TEntity : IEntity<TKey>
    {
        Task SaveAsync(TEntity entity);

        Task DeleteAsync(TKey id);

        Task<TEntity> GetAsync(TKey id);

        Task<IEnumerable<TEntity>> GetAsync(IEnumerable<TKey> ids);

        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
