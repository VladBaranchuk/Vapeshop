using Veipshop.Model;
using Veipshop.Service;

namespace Veipshop.ViewModel
{
    public class VapingLiquidVM : ViewModelBase
    {
        private int productId;
        public int ProductId
        {
            get { return productId; }
            set
            {
                productId = value;
                OnPropertyChanged("ProductId");
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private int? price;
        public int? Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        private string taste;
        public string Taste
        {
            get { return taste; }
            set
            {
                taste = value;
                OnPropertyChanged("Taste");
            }
        }

        private string volume;
        public string Volume
        {
            get { return volume; }
            set
            {
                volume = value;
                OnPropertyChanged("Volume");
            }
        }

        private string strong;
        public string Strong
        {
            get { return strong; }
            set
            {
                strong = value;
                OnPropertyChanged("Strong");
            }
        }

        private Vaping_liquid vapingLiquid;

        public VapingLiquidVM(Products product)
        {
            vapingLiquid = ProductModel.ProductToVapingLiquid(product);

            ProductId = product.product_id;
            Name = product.name;
            Price = product.price;

            Taste = vapingLiquid.taste;
            Volume = vapingLiquid.volume;
            Strong = vapingLiquid.strong;
        }

        private RelayCommand basketCommand;
        public RelayCommand BasketCommand
        {
            get
            {
                return basketCommand ??
                  (basketCommand = new RelayCommand(obj =>
                  {
                      BasketModel.setOrder(ProductId);
                  }));
            }
        }
    }
}
