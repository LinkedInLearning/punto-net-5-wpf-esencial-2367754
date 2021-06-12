using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using Wisdom.Models;
using Wisdom.Services;
using Wisdom.Views;

namespace Wisdom.ViewModels
{
    public class ProductsViewModel : BindableBase
    {
        private readonly IProductsService productsService;

        private ObservableCollection<Product> products;

        public ObservableCollection<Product> Products
        {
            get
            {
                return products;
            }
            set
            {
                SetProperty(ref products, value);
            }
        }

        private Product selectedProduct;
        
        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                SetProperty(ref selectedProduct, value);
            }
        }


        public DelegateCommand AddProductCommand { get; set; }
        public DelegateCommand EditProductCommand { get; set; }

        public ProductsViewModel(IProductsService productsService)
        {
            this.productsService = productsService;

            AddProductCommand = new DelegateCommand(AddProduct, CanAddProduct);
            EditProductCommand = new DelegateCommand(EditProduct, CanEditProduct)
                .ObservesProperty(() => SelectedProduct);

            LoadProducts();
        }

        private void EditProduct()
        {
            var productToEdit = SelectedProduct.Clone() as Product;
            var productDetailWindow = new ProductDetail(productToEdit);
            if (productDetailWindow.ShowDialog() == true)
            {
                productsService.Update(SelectedProduct.Id, productToEdit);
                LoadProducts();
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
                productsService.Add(newProduct);
                LoadProducts();
            }
        }

        private void LoadProducts()
        {
            if (productsService == null)
            {
                return;
            }
            var results = productsService.GetAll();
            Products = new ObservableCollection<Product>(results);
        }
    }
}
