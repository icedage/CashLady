using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashLady.CqrsLib
{
    public interface Handler<T>
    {
        void Handle(T @event);
    }
}
