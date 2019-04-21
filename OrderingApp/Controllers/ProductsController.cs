using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using OrderingApp.Models;

namespace OrderingApp.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly OnlineOrderingDbContext db = new OnlineOrderingDbContext();

        // GET: api/Products
        public IEnumerable<ProductVM> GetProduct()
        {
            var products = db.Product.ToList();
            var productsVM = Mapper.Map<List<Product>, List<ProductVM>>(products);

            return productsVM;
        }

        // GET: api/Products/5
        [ResponseType(typeof(ProductVM))]
        public IHttpActionResult GetProduct(int id)
        {
            Product product = db.Product.Find(id);
            var productVM = Mapper.Map<Product, ProductVM>(product);

            if (productVM == null)
            {
                return NotFound();
            }

            return Ok(productVM);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(int id, ProductVM productVm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = Mapper.Map<ProductVM, Product>(productVm);

            if (id != product.Id)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Products
        [ResponseType(typeof(ProductVM))]
        public IHttpActionResult PostProduct(ProductVM productVm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = Mapper.Map<ProductVM, Product>(productVm);

            db.Product.Add(product);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(ProductVM))]
        public IHttpActionResult DeleteProduct(int id)
        {
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Product.Remove(product);
            db.SaveChanges();

            var productVM = Mapper.Map<Product, ProductVM>(product);

            return Ok(productVM);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Product.Count(e => e.Id == id) > 0;
        }
    }
}