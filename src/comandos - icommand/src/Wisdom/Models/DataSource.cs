using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wisdom.Commands;

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

        public WisdomCommand AddProductCommand { get; set; }

        public DataSource()
        {
            AddProductCommand = new WisdomCommand(AddProduct, CanAddProduct);
        }

        private bool CanAddProduct()
        {
            return true;
        }

        private void AddProduct()
        {
            if (Products == null)
            {
                Products = new ObservableCollection<Product>();
            }

            var newProduct = new Product();
            var productDetailWindow = new ProductDetail(newProduct);
            if (productDetailWindow.ShowDialog() == true)
            {
                Products.Add(newProduct);
            }
        }
    }
}
