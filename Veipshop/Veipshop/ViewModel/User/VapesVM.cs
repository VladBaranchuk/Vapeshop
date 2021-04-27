using Veipshop.Model;
using Veipshop.Service;

namespace Veipshop.ViewModel
{
    public class VapesVM : ViewModelBase
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

        private string peakPower;
        public string PeakPower
        {
            get { return peakPower; }
            set
            {
                peakPower = value;
                OnPropertyChanged("PeakPower");
            }
        }

        private Vapes vapes;

        public VapesVM(Products product)
        {
            vapes = ProductModel.ProductToVapes(product);

            ProductId = product.product_id;
            Name = product.name;
            Price = product.price;

            PeakPower = vapes.peak_power;
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
