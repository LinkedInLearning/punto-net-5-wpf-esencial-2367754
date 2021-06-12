using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using Wisdom.Modules.Web.ViewModels;
using Wisdom.Modules.Web.Views;

namespace Wisdom.Modules.Web
{
    public class WebModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            containerProvider.Resolve<IRegionManager>()
                .RequestNavigate("MainRegion", nameof(WebView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<WebView, WebViewModel>();
        }
    }
}