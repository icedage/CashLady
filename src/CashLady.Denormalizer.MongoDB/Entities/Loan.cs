using CashLady.Denormalizer.MongoDB.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace CashLady.Denormalizer.MongoDB.Repositories
{
    public class Loan :IEntity
    {
        public Guid LoanId { get; set; }

        [BsonId]
        public string Id { get; set; }

        public decimal Apr { get; set; }

        public int Term { get; set; }

        public decimal MonthlyPayment { get; set; }

        public decimal LoanAmount { get; set; }

        public string FriendlyLoanReference { get; set; }

        public decimal OriginationFee { get; set; }

        public decimal TotalRepayment { get; set; }

        public decimal TotalInterest { get; set; }
    }
}