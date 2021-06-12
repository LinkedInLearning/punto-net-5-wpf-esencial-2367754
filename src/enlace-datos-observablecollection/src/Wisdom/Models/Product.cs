namespace Wisdom.Models
{
    public class Product : BindableBase
    {
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

        public override string ToString()
        {
            return Name;
        }
    }
}