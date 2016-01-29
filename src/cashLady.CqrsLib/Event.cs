using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashLady.CqrsLib
{
    public class Event : IMessage
    {
        public Event()
        {
            this.Timestamp = DateTime.UtcNow;
        }

        public int Version;

        public DateTime Timestamp { get; set; }
    }
}
