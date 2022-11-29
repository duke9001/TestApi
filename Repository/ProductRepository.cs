using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Models;

namespace TestApi.Repository
{
    public class ProductRepository : IProduct
    {
        private readonly DBContext _context;
        public ProductRepository(DBContext context)
        {
            _context = context;
        }

        public bool DeleteProduct(long id)
        {
            try
            {
                var product = _context.Products.Find(id);
                if (product == null)
                {
                    return false;
                }

                _context.Products.Remove(product);
                _context.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public Product GetProduct(long id)
        {
            var product =  _context.Products.Find(id);           
            return product;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public bool PostProduct(Product product)
        {
            if (product == null)
            {
                return false;
            }
            else
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return true;
            }
        }

        public bool ProductExists(long id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }

        public bool PutProduct(long id, Product product)
        {
            if (id != product.ProductId)
            {
                return false;
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
            return true;
        }
    }
}
