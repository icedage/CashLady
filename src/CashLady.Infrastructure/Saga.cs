using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashLady.Infrastructure
{
    public abstract class Saga
    {
        public IBus Bus { get; private set; }
    }
}
