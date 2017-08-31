using MarcelloDB.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarColors.Data.Repositories;

namespace WarColors.Data.Marcello
{
    public class RepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : IEntity<TKey>
    {
        protected IDatabase db;
        protected Collection<TEntity, TKey> collection;

        public RepositoryBase(IDatabase database)
        {
            this.db = database;
            collection = this.db.GetCollection<TEntity, TKey>();
        }

        public Task DeleteAsync(TKey id)
        {
            return Task.Run(() => collection.Destroy(id));
        }

        public Task<TEntity> GetAsync(TKey id)
        {
            return Task.Run(() => collection.Find(id));
        }

        public Task<IEnumerable<TEntity>> GetAsync(IEnumerable<TKey> ids)
        {
            return Task.Run(() => collection.Find(ids));
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return Task.Run(() => collection.All);
        }

        public Task SaveAsync(TEntity entity)
        {
            return Task.Run(() => collection.Persist(entity));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
        }
    }
}
