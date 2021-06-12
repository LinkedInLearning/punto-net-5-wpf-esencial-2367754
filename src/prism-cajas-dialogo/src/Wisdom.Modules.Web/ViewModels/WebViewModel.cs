using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wisdom.Modules.Web.ViewModels
{
    public class WebViewModel : BindableBase
    {
        private string title;

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public WebViewModel()
        {
            Title = "Portal Web";
        }
    }
}
