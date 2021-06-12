using System.Windows;
using Wisdom.Models;

namespace Wisdom
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