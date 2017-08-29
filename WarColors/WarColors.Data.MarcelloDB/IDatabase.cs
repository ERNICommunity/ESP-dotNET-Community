﻿using MarcelloDB.Collections;
using MarcelloDB.Index;
using WarColors.Data.Repositories;

namespace WarColors.Data.Marcello
{
    public interface IDatabase
    {
        Collection<TEntity, TKey, TIndexDef> GetCollection<TEntity, TKey, TIndexDef>()
            where TEntity : IEntity<TKey>
            where TIndexDef : IndexDefinition<TEntity>, new();
        Collection<TEntity, TKey> GetCollection<TEntity, TKey>() where TEntity : IEntity<TKey>;
    }
}