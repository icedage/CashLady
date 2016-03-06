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
    }
}