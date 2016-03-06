using CashLady.Denormalizer.MongoDB.Entities;
using System.Collections.Generic;
using MongoDB.Driver;
using System;

namespace CashLady.Denormalizer.MongoDB.MongoRepository
{
    public class MongoRepository<T> : IMongoRepository<T> where T : IEntity
    {
        private readonly string _collectionName;
        MongoContextProvider _contextProvider;

        public MongoRepository(MongoContextProvider contextProvider, string collectionName)
        {
            _contextProvider = contextProvider;
            _collectionName = collectionName;
        }

        protected MongoCollection<T> Collection
        {
            get
            {
                return _contextProvider.GetCollection<T>(_collectionName);
            }
        }

        protected MongoDatabase Database
        {
            get
            {
                return _contextProvider.Database;
            }
        }

        public void Add(IEnumerable<T> entities)
        {
            Collection.InsertBatch<T>(entities);
        }

        public void Add(T entity)
        {
            Collection.Insert<T>(entity);
        }

        public T GetById(string id)
        {
            return Collection.FindOneByIdAs<T>(id);
        }

        public void Save(T entity)
        {
            try
            {
                Collection.Save<T>(entity);
            }
            catch (Exception ex)
            { }
        }
    }
}
