using System.Collections.Generic;
using Wisdom.Models;

namespace Wisdom.Services
{
    public interface IProductsService
    {
        IEnumerable<Product> GetAll();
        void Add(Product product);
        void Update(int id, Product product);
    }
}