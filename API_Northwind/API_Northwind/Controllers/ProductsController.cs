using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API_Northwind.Models;

namespace API_Northwind.Controllers
{
    public class ProductsController : ApiController
    {
        NORTHWNDEntities db = new NORTHWNDEntities();

        public IHttpActionResult GetProducts()
        {
            var product = db.Products.ToList();
            return Ok(product);
        }

        public HttpResponseMessage GetProduct(int id)
        {
            Product product = db.Products.FirstOrDefault(x => x.ProductID == id);
            if(product != null)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, product);
                return response;
            }
            else
            {
                HttpResponseMessage errorResponse = Request.CreateResponse(HttpStatusCode.NotFound, "Product not found!");
                return errorResponse;
            }
        }

        public IHttpActionResult PostProduct(Product product)
        {
            if(product == null)
            {
                return BadRequest();
            }
            else
            {
                db.Products.Add(product);
                return Ok();
            }
        }

        public IHttpActionResult PutProduct(Product product)
        {
            Product updated = db.Products.FirstOrDefault(x=>x.ProductID == product.ProductID);
            if(updated == null)
            {
                return NotFound();
            }
            else
            {
                db.Entry(updated).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Ok();
            }
        }

        public IHttpActionResult DeleteProduct(int id)
        {
            try
            {
                Product deleted = db.Products.Find(id);
                db.Entry(deleted).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
