using Veipshop.Model;
using Veipshop.Service;

namespace Veipshop.ViewModel
{
    public class THSVM : ViewModelBase
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

        private string batteryCapacity;
        public string BatteryCapacity
        {
            get { return batteryCapacity; }
            set
            {
                batteryCapacity = value;
                OnPropertyChanged("BatteryCapacity");
            }
        }

        private Tobacco_heating_systems ths;

        public THSVM(Products product)
        {
            ths = ProductModel.ProductToTHS(product);

            ProductId = product.product_id;
            Name = product.name;
            Price = product.price;

            BatteryCapacity = ths.battery_capacity;
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
