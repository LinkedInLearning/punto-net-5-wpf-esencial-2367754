using Prism.Mvvm;
using System;

namespace Wisdom.Modules.Products.Models
{
    public class Product : BindableBase, ICloneable
    {
        private int id;

        public int Id
        {
            get { return id; }
            set
            {
                SetProperty(ref id, value);
            }
        }


        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                SetProperty(ref name, value);
            }
        }

        private string brand;

        public string Brand
        {
            get { return brand; }
            set
            {
                SetProperty(ref brand, value);
            }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set
            {
                SetProperty(ref description, value);
            }
        }

        private decimal? price;

        public decimal? Price
        {
            get { return price; }
            set
            {
                SetProperty(ref price, value);
            }
        }


        public override string ToString()
        {
            return Name;
        }

        public object Clone()
        {
            return new Product()
            {
                Id = Id,
                Name = Name,
                Brand = Brand,
                Description = Description,
                Price = Price
            };
        }
    }
}