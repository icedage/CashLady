using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashLady.CqrsLib
{
    public class Command : IMessage
    {
        public Command()
        {
            this.Timestamp = DateTime.UtcNow;
        }

        public DateTime Timestamp { get; set; }
    }
}
