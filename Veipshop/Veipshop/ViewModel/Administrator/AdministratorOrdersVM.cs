using Veipshop.Model;
using System.Collections.ObjectModel;
using Veipshop.Model.Ords;
using Veipshop.Service;

namespace Veipshop.ViewModel.Administrator
{
    public class AdministratorOrdersVM : ViewModelBase
    {
        public ObservableCollection<B> Baskets { get; set; }

        public AdministratorOrdersVM()
        {
            Baskets = BasketModel.getAllOrders();
        }

        private RelayCommand orderCommand;
        public RelayCommand OrderCommand
        {
            get
            {
                return orderCommand ??
                  (orderCommand = new RelayCommand(obj =>
                  {
                      B b = obj as B;

                      BasketModel.toConfirm(b.basket_id);
                      Baskets.Remove(b);
                  }));
            }
        }
    }
}
