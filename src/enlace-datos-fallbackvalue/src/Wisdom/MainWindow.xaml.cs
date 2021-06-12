using System;
using System.Windows;
using Wisdom.Models;

namespace Wisdom
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var newProduct = new Product();
            var productDetailWindow = new ProductDetail(newProduct);
            if (productDetailWindow.ShowDialog() == true)
            {
                (DataContext as DataSource).AddProduct(newProduct);
            }
        }
    }
}