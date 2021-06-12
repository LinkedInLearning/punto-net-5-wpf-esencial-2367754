using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Wisdom.Modules.Products.Services;
using Wisdom.Modules.Products.ViewModels;
using Wisdom.Modules.Products.Views;

namespace Wisdom.Modules.Products
{
    public class ProductsModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            containerProvider.Resolve<IRegionManager>()
                .RequestNavigate("MainRegion", nameof(ProductsView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ProductsView, ProductsViewModel>();
            containerRegistry.Register<IProductsService, ProductsService>();
        }
    }
}
