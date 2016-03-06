using CashLady.Denormalizer.MongoDB.MongoRepository;
using CashLady.Denormalizer.MongoDB.Entities;

namespace CashLady.Denormalizer.MongoDB.Repositories
{
    public class UserViewRepository : MongoRepository<User>, IUserViewRepository
    {
        public UserViewRepository(MongoContextProvider context)
           : base(context, "UserViewRepository")
        {
        }
    }
}
