using System.Collections.ObjectModel;
using Wisdom.Commands;
using Wisdom.Models;
using Wisdom.Services;
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
        private readonly IProductsService productsService;

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

        public ProductsViewModel() : this(new ProductsService())
        {
        }
        public ProductsViewModel(IProductsService productsService)
        {
            this.productsService = productsService;

            AddProductCommand = new WisdomCommand(AddProduct, CanAddProduct);
            EditProductCommand = new WisdomCommand(EditProduct, CanEditProduct);

            PropertyChanged += DataSource_PropertyChanged;

            LoadProducts();
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
            var results = productsService.GetAll();
            Products = new ObservableCollection<Product>(results);
        }
    }
}
