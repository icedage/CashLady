using CashLady.Denormalizer.MongoDB.MongoRepository;
using CashLady.Denormalizer.MongoDB.Repositories;
using CashLady.Domain.Version1.Commands;
using MassTransit;
using MongoDB.Bson;
using System;
using System.Threading.Tasks;

namespace CashLady.Denormalizer
{
    public class LoansView : IConsumer<ApplyForLoan>
    {
        private  ILoansViewRepository _loansViewRepository;

        public LoansView()
        {
           
        }

        public Task Consume(ConsumeContext<ApplyForLoan> context)
        {
            var loan = new Loan() { LoanId= Guid.NewGuid(), Id = ObjectId.GenerateNewId().ToString()};
            MongoContextProvider contextProvider = new MongoContextProvider("MongoDBconnection", "LoansViewRepository");
            _loansViewRepository = new LoansViewRepository(contextProvider);
           _loansViewRepository.Save(loan);

            //return Task.FromResult(0);
            return Task.FromResult(0);
        }
    }
}
