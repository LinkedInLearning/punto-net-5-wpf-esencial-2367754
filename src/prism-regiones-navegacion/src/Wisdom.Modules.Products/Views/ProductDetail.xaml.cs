using System.Windows;
using Wisdom.Modules.Products.Models;

namespace Wisdom.Modules.Products.Views
{
    public partial class ProductDetail : Window
    {
        public ProductDetail(Product product)
        {
            InitializeComponent();
            DataContext = product;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}