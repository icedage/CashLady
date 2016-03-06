using CashLady.Denormalizer.MongoDB.Entities;
using CashLady.Denormalizer.MongoDB.MongoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashLady.Denormalizer.MongoDB.Repositories
{
    public interface IUserViewRepository : IMongoRepository<User>
    {
     
    }
}
