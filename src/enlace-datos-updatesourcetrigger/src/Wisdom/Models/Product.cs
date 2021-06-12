namespace Wisdom.Models
{
    public class Product : BindableBase
    {
        private string name;
        private string description;
        public string Name { get => name;
            set 
            {
                name = value;
                OnPropertyChanged();
            }
        }
        public string Description { get => description; set
            {
                description = value;
                OnPropertyChanged();
            }
        }

        
    }
}