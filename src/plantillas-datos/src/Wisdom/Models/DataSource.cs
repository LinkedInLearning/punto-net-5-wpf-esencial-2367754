using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wisdom.Models
{
    public class DataSource : BindableBase
    {
        private ObservableCollection<Product> products;

        public ObservableCollection<Product> Products
        {
            get
            {
                return products;
            }
            set
            {
                products = value;
                OnPropertyChanged();
            }
        }

        public void AddProduct(Product product)
        {
            if (Products == null)
            {
                Products = new ObservableCollection<Product>();
            }

            Products.Add(product);
        }
    }
}
