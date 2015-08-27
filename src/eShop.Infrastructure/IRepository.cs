using Raven.Client.Indexes;
using System;

namespace eShop.Infrastructure
{
    public interface IRepository
    {
        void Save<T>(T item) where T : IAggregate;

        T GetById<T>(Guid id) where T : IAggregate;

        T GerById<T, K>(Guid id)
            where T : IAggregate
            where K : AbstractIndexCreationTask, new();
    }
}
