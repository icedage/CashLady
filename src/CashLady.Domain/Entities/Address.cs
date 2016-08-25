using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashLady.Domain.Entities
{
    public class Address
    {
        public string FirstLine { get; set; }

        public string PostCode { get; set; }

        public DateTime DateMovedIn { get; set; }

        public DateTime DateMovedOut { get; set; }

        public string County { get; set; }

        public string City { get; set; }
    }
}
