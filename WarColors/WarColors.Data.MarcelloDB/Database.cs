using MarcelloDB;
using MarcelloDB.Collections;
using MarcelloDB.Index;
using MarcelloDB.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarColors.Data.Entities;
using WarColors.Data.Repositories;

namespace WarColors.Data.Marcello
{
    public class Database : IDatabase
    {
        private const string SessionName = "warcolors.dat";

        private IPlatform platform;
        private Session session;
        private CollectionFile database;

        public Database(IPlatform platform, string path)
        {
            this.platform = platform;
            session = new Session(platform, path);
            database = session[SessionName];
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                database = null;
                session.Dispose();
            }
        }

        public Collection<TEntity, TKey, TIndexDef> GetCollection<TEntity, TKey, TIndexDef>() 
            where TIndexDef : IndexDefinition<TEntity>, new() 
            where TEntity : IEntity<TKey>
        {
            return database.Collection<TEntity, TKey, TIndexDef>(typeof(TEntity).Name, e => e.Id);
        }

        public Collection<TEntity, TKey> GetCollection<TEntity, TKey>()
            where TEntity : IEntity<TKey>
        {
            return database.Collection<TEntity, TKey>(typeof(TEntity).Name, e => e.Id);
        }
    }
}
