using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API_Northwind.Models;

namespace API_Northwind.Controllers
{
    public class OrdersController : ApiController
    {
        NORTHWNDEntities db = new NORTHWNDEntities();

        public IHttpActionResult GetOrders()
        {
            return Ok(db.Orders.ToList());
        }
    }
}
