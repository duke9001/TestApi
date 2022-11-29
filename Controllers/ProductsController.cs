using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApi.Models;
using TestApi.Repository;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProduct _Iproduct;

        public ProductsController(IProduct product)
        {
            _Iproduct = product;
        }


        // GET: api/Products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
           return Ok(_Iproduct.GetProducts());
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(long id)
        {
            var product = _Iproduct.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult PutProduct(long id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            try
            {
                _Iproduct.PutProduct(id, product);
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

            return NoContent();
        }

        // POST: api/Products
        [HttpPost]
        [Authorize]
        public ActionResult<Product> PostProduct(Product product)
        {
            try
            {
                bool result = _Iproduct.PostProduct(product);
                if (result == true)
                {
                    return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
                }
            }
            catch
            {
                return BadRequest();
            }

            return BadRequest();
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult<Product> DeleteProduct(long id)
        {
            var result = _Iproduct.DeleteProduct(id);
            if (result == true)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        private bool ProductExists(long id)
        {
            return _Iproduct.ProductExists(id);
        }
    }
}
