using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API_Northwind.Models;

namespace API_Northwind.Controllers
{
    public class CustomersController : ApiController
    {
        NORTHWNDEntities db = new NORTHWNDEntities();

        public IHttpActionResult GetCustomers()
        {
            return Ok(db.Customers.ToList());
        }
    }
}
