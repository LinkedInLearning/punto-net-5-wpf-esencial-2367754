using Wisdom.Modules.Products.Services;
using Wisdom.Modules.Products.ViewModels;
using Xunit;

namespace Wisdom.Tests
{
    public class ProductsViewModelTest
    {
        [Fact]
        public void ViewModelLoadsDataSuccessfully()
        {
            var ps = new ProductsService();
            var vm = new ProductsViewModel(ps);
            Assert.NotNull(vm.Products);
            Assert.True(vm.Products.Count > 0);
        }
    }
}
