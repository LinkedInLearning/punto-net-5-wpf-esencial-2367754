using System.Collections.Generic;
using Wisdom.Modules.Products.Models;

namespace Wisdom.Modules.Products.Services
{
    public interface IProductsService
    {
        IEnumerable<Product> GetAll();
        void Add(Product product);
        void Update(int id, Product product);
    }
}