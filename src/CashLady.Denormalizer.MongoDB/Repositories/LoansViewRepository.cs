using CashLady.Denormalizer.MongoDB.MongoRepository;

namespace CashLady.Denormalizer.MongoDB.Repositories
{
    public class LoansViewRepository : MongoRepository<Loan>, ILoansViewRepository
    {
        public LoansViewRepository(MongoContextProvider context)
           : base(context, "LoansViewRepository")
        {
        }
    }
}
