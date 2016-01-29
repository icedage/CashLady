using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashLady.CqrsLib
{
    public interface ICommandSender
    {
        void Send<T>(T command) where T : Command;
    }
}
