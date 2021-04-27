using Veipshop.Model;
using Veipshop.Service;

namespace Veipshop.ViewModel
{
    public class PodVM : ViewModelBase
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

        private Pod pod;

        public PodVM(Products product)
        {
            pod = ProductModel.ProductToPod(product);

            ProductId = product.product_id;
            Name = product.name;
            Price = product.price;

            BatteryCapacity = pod.battery_capacity;
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
