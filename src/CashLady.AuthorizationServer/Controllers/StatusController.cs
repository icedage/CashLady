using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CashLady.AuthorizationServer.Controllers
{
    public class StatusController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok("OK");
        }
    }
}
