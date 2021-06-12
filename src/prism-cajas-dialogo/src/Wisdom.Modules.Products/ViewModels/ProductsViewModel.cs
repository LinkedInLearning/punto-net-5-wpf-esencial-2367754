using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System.Collections.ObjectModel;
using Wisdom.Modules.Products.Models;
using Wisdom.Modules.Products.Services;
using Wisdom.Modules.Products.Views;

namespace Wisdom.Modules.Products.ViewModels
{
    public class ProductsViewModel : BindableBase
    {
        private readonly IProductsService productsService;
        private readonly IDialogService dialogService;
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

        public ProductsViewModel(IProductsService productsService,
            IDialogService dialogService)
        {
            this.productsService = productsService;
            this.dialogService = dialogService;
            AddProductCommand = new DelegateCommand(AddProduct, CanAddProduct);
            EditProductCommand = new DelegateCommand(EditProduct, CanEditProduct)
                .ObservesProperty(() => SelectedProduct);
            Title = "Productos";
            LoadProducts();
        }

        private void EditProduct()
        {
            var productToEdit = SelectedProduct.Clone() as Product;
            var dialogParameters = new DialogParameters();
            dialogParameters.Add("product", productToEdit);
            dialogService.ShowDialog("ProductDetail", dialogParameters, cb =>
            {
                if (cb.Result == ButtonResult.OK)
                {
                    productsService.Update(SelectedProduct.Id, productToEdit);
                    LoadProducts();
                }
            });
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
            var dialogParameters = new DialogParameters();
            dialogParameters.Add("product", newProduct);
            dialogService.ShowDialog("ProductDetail", dialogParameters, cb =>
            {
                if (cb.Result == ButtonResult.OK)
                {
                    productsService.Add(newProduct);
                    LoadProducts();
                }
            });
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
