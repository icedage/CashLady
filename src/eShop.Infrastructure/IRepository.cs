using Raven.Client.Indexes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
