using Veipshop.Model;
using System.Collections.ObjectModel;
using Veipshop.Service;

namespace Veipshop.ViewModel
{
    public class BasketVM : ViewModelBase
    {
        public ObservableCollection<Products> Products { get; set; }

        public BasketVM()
        {
            Products = BasketModel.getBasket();
        }

        private RelayCommand basketCommand;
        public RelayCommand BasketCommand
        {
            get
            {
                return basketCommand ??
                  (basketCommand = new RelayCommand(obj =>
                  {
                      Products Product = obj as Products;
                      if (Product != null)
                      {
                          BasketModel.removeProductFromBasket(Product.product_id);
                          Products.Remove(Product);
                      }
                  }));
            }
        }

        private RelayCommand toOrderCommand;
        public RelayCommand ToOrderCommand
        {
            get
            {
                return toOrderCommand ??
                  (toOrderCommand = new RelayCommand(obj =>
                  {
                      BasketModel.toOrder();
                      Products.Clear();
                  }));
            }
        }
    }
}
