using System;
using System.Collections.ObjectModel;
using Wisdom.Modules.Products.Models;
using Wisdom.Modules.Products.ViewModels;

namespace Wisdom.Modules.Products.Fakes
{
    internal class FakeProductsViewModel : ProductsViewModel
    {
        public FakeProductsViewModel() : base(null, null)
        {
            Products = new ObservableCollection<Product>();
            Products.Add(new Product()
            {
                Name = "Product1",
                Brand = "Wisdom",
                Description = Guid.NewGuid().ToString(),
                Price = 30
            });
            Products.Add(new Product()
            {
                Name = "Product2",
                Brand = "Wisdom",
                Description = Guid.NewGuid().ToString(),
                Price = 60
            });
            Products.Add(new Product()
            {
                Name = "Product3",
                Brand = "Wisdom",
                Description = Guid.NewGuid().ToString(),
                Price = 20
            });
        }
    }
}