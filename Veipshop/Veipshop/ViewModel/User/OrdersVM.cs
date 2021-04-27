using Veipshop.Model;
using System.Collections.ObjectModel;
using Veipshop.Model.Ords;


namespace Veipshop.ViewModel
{
    public class OrdersVM : ViewModelBase
    {
        public ObservableCollection<B> Baskets { get; set; }  

        public OrdersVM()
        {
            Baskets = BasketModel.getOrders();
        }

    }
}
