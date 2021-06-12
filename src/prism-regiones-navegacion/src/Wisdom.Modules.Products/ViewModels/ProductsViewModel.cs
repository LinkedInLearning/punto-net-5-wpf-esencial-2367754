using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using Wisdom.Modules.Products.Models;
using Wisdom.Modules.Products.Services;
using Wisdom.Modules.Products.Views;

namespace Wisdom.Modules.Products.ViewModels
{
    public class ProductsViewModel : BindableBase
    {
        private readonly IProductsService productsService;

        private string title;

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }


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
            Title = "Productos";
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
