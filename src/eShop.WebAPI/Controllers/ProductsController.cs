using eShop.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace eShop.WebAPI.Controllers
{
    public class ProductsController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Post(ProductRequest request)
        {
            return Ok();
        }
    }
}
