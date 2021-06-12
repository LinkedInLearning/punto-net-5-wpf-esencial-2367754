namespace Wisdom.Models
{
    public class Product : BindableBase
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value;
                OnPropertyChanged();
            }
        }


        private string name;

        public string Name
        {
            get { return name; }
            set { name = value;
                OnPropertyChanged();
            }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value;
                OnPropertyChanged();
            }
        }

        private decimal? price;

        public decimal? Price
        {
            get { return price; }
            set { price = value;
                OnPropertyChanged();
            }
        }


        public override string ToString()
        {
            return Name;
        }
    }
}