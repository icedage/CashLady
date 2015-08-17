using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashLady.Infrastructure
{
    public interface IHandleMessage<in T> 
    {
        void Handle(T Message);
    }
}
