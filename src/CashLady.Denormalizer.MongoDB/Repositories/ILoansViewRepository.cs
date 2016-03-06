using CashLady.Denormalizer.MongoDB.MongoRepository;
using CashLady.Denormalizer.MongoDB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashLady.Denormalizer.MongoDB.MongoRepository
{
    public interface ILoansViewRepository : IMongoRepository<Loan>
    {
        
    }
}
