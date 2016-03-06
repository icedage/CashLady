using CashLady.Denormalizer.MongoDB.Entities;
using System.Collections.Generic;

namespace CashLady.Denormalizer.MongoDB.MongoRepository
{
    public interface IMongoRepository<T> where T : IEntity
    {
        T GetById(string id);

        void Add(T entity);

        void Add(IEnumerable<T> entities);

        void Save(T entity);
    }
}
