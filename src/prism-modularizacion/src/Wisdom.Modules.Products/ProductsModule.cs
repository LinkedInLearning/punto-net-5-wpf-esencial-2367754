using Prism.Ioc;
using Prism.Modularity;

namespace Wisdom.Modules.Products
{
    public class ProductsModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry.Register<IProductsService, ProductsService>();
        }
    }
}
