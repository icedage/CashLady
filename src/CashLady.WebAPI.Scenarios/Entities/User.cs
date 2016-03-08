using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashLady.WebAPI.Scenarios.Helpers
{
    public class User
    {
        public string username { get; set; }

        public string password { get; set; }

        public string grant_type { get; set; }

        public string access_token { get; set; }

        public string token_type { get; set; }

        public int expires_in { get; set; }
    }
}
