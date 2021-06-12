using System.Collections.ObjectModel;
using Wisdom.Commands;
using Wisdom.Models;
using Wisdom.Views;

namespace Wisdom.ViewModels
{
    public class ProductsViewModel : BindableBase
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

        private Product selectedProduct;

        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                OnPropertyChanged();
            }
        }


        public WisdomCommand AddProductCommand { get; set; }
        public WisdomCommand EditProductCommand { get; set; }

        public ProductsViewModel()
        {
            AddProductCommand = new WisdomCommand(AddProduct, CanAddProduct);
            EditProductCommand = new WisdomCommand(EditProduct, CanEditProduct);

            PropertyChanged += DataSource_PropertyChanged;
        }

        private void DataSource_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SelectedProduct))
            {
                EditProductCommand.RaiseCanExecuteChanged();
            }
        }

        private void EditProduct()
        {
            var productToEdit = SelectedProduct.Clone() as Product;
            var productDetailWindow = new ProductDetail(productToEdit);
            if (productDetailWindow.ShowDialog() == true)
            {
                SelectedProduct.Name = productToEdit.Name;
                SelectedProduct.Description = productToEdit.Description;
            }
        }

        private bool CanEditProduct()
        {
            return SelectedProduct != null;
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
