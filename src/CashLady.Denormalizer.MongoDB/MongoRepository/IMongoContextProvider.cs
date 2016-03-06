using System;
using MongoDB.Driver;

namespace CashLady.Denormalizer.MongoDB.MongoRepository
{
    public interface IMongoContextProvider
    {
        MongoCollection<T> GetCollection<T>(string collectionName);
    }
}
