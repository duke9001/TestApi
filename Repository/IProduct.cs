using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Models;

namespace TestApi.Repository
{
    public interface IProduct
    {
        public IEnumerable<Product> GetProducts();
        public Product GetProduct(long id);
        public bool PutProduct(long id, Product product);
        public bool PostProduct(Product product);
        public bool DeleteProduct(long id);
        public bool ProductExists(long id);


    }
}
