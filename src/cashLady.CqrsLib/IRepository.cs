using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashLady.CqrsLib
{
    public interface IRepository<T> where T : AggregateRoot
    {
        void Save(AggregateRoot aggregate);

        T GetById(Guid id);
    }
}
