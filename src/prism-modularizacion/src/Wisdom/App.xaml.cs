using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using Wisdom.Modules.Products;
using Wisdom.Modules.Web;
using Wisdom.Views;

namespace Wisdom
{
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ProductsModule>();
            moduleCatalog.AddModule<WebModule>();
        }
    }
}
