using System.Collections.Generic;
using System.Linq;
using Wisdom.Modules.Products.Models;

namespace Wisdom.Modules.Products.Services
{
    public class ProductsService : IProductsService
    {
        private readonly List<Product> products = new List<Product>();
        public ProductsService()
        {
            products.Add(new Product()
            {
                Id = 1,
                Name = "Collar para perro",
                Brand = "Wisdom",
                Description = "Collar para perro color rojo",
                Price = 20
            });
            products.Add(new Product()
            {
                Id = 2,
                Name = "Collar para gato",
                Brand = "Wisdom",
                Description = "Collar para gato color verde",
                Price = 22
            });
        }

        public void Add(Product product)
        {
            product.Id = products.Max(p => p.Id) + 1;
            products.Add(product);
        }

        public IEnumerable<Product> GetAll()
        {
            return products.AsEnumerable();
        }

        public void Update(int id, Product product)
        {
            var productToEdit = products.First(p => p.Id == id);
            productToEdit.Name = product.Name;
            productToEdit.Brand = product.Brand;
            productToEdit.Description = product.Description;
            productToEdit.Price = product.Price;
        }
    }
}
