using System.Collections.ObjectModel;

namespace Veipshop.Model.Ords
{
    public class B
    {
        public int basket_id { get; set; }
        public string complete { get; set; }
        public string confirm { get; set; }

        public ObservableCollection<P> Product { get; set; }
    }
}
