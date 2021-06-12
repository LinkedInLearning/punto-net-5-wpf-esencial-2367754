using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wisdom.Models;
using Wisdom.ViewModels;

namespace Wisdom.Fakes
{
    internal class FakeDataSource : ProductsViewModel
    {
        public FakeDataSource()
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