using CashLady.Denormalizer.MongoDB.MongoRepository;
using CashLady.Denormalizer.MongoDB.Repositories;
using CashLady.Domain.Version1.Commands;
using MassTransit;
using MongoDB.Bson;
using System;
using System.Threading.Tasks;
using System.Configuration;

namespace CashLady.Denormalizer
{
    public class LoansView : IConsumer<ApplyForLoan>
    {
        private  ILoansViewRepository _loansViewRepository;

        public LoansView()
        {
            //TODO : Need to fix the denendency issue with the ILoansViewRepository!!
            var connection = ConfigurationManager.AppSettings["MongoDBconnection"];
            MongoContextProvider contextProvider = new MongoContextProvider(connection, "LoansViewRepository");
            _loansViewRepository = new LoansViewRepository(contextProvider);
        }

        public Task Consume(ConsumeContext<ApplyForLoan> context)
        {
            var loan = new Loan() { LoanId= Guid.NewGuid(),
                                    Id = ObjectId.GenerateNewId().ToString(),
                                    TotalInterest = context.Message.TotalInterest,
                                    Apr = context.Message.Apr,
                                    LoanAmount = context.Message.LoanAmount,
                                    MonthlyPayment = context.Message.MonthlyPayment,
                                    OriginationFee = context.Message.OriginationFee,
                                    Term = context.Message.Term,
                                    TotalRepayment = context.Message.TotalRepayment,
                                };
            MongoContextProvider contextProvider = new MongoContextProvider("MongoDBconnection", "LoansViewRepository");
            _loansViewRepository = new LoansViewRepository(contextProvider);
           _loansViewRepository.Save(loan);
            return Task.FromResult(0);
        }
    }
}
