using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wisdom.Models
{
    public class DataSource
    {
        public ObservableCollection<Product> Products { get; set; }

        public DataSource()
        {
            Products = new ObservableCollection<Product>();
            Products.Add(new Product()
            {
                Name = "Collar para perro",
                Description = "Collar para perro color rojo"
            });
            Products.Add(new Product()
            {
                Name = "Pelota para gatos",
                Description = "Pelota para gatos de 10 cm"
            });

        }
    }
}
