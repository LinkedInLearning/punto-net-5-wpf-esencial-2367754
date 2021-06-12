using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using Wisdom.Modules.Products.Models;

namespace Wisdom.Modules.Products.Dialogs
{
    public class ProductDetailViewModel : BindableBase, IDialogAware
    {
        private Product product;

        public Product Product
        {
            get { return product; }
            set { SetProperty(ref product, value); }
        }

        public string Title => "Detalle de producto";

        public event Action<IDialogResult> RequestClose;

        public DelegateCommand AcceptCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }

        public ProductDetailViewModel()
        {
            AcceptCommand = new DelegateCommand(() =>
            {
                RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
            });
            CancelCommand = new DelegateCommand(() =>
            {
                RequestClose?.Invoke(new DialogResult(ButtonResult.Cancel));
            });
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {

        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            if (parameters.ContainsKey("product"))
            {
                Product = parameters.GetValue<Product>("product");
            }
        }
    }
}
