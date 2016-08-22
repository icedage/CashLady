using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CashLady.WebAPI.Controllers
{
    public class StatusController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok();
        }

    }
}
