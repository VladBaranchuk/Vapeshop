using Veipshop.Model;
using Veipshop.Service;

namespace Veipshop.ViewModel.Administrator
{
    public class AdministratorVapesVM : ViewModelBase
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

        private AppAdministratorVM _currentVM;
        public AppAdministratorVM CurrentVM
        {
            get => _currentVM;
            set
            {
                if (_currentVM == value)
                {
                    return;
                }
                _currentVM = value;
                OnPropertyChanged("CurrentVM");
            }
        }

        private Vapes vapes;

        private int? _sectionId;

        public AdministratorVapesVM(Products product, ViewModelBase currentVM)
        {
            CurrentVM = currentVM as AppAdministratorVM;

            _sectionId = product.section_id;

            vapes = ProductModel.ProductToVapes(product);

            ProductId = product.product_id;
            Name = product.name;
            Price = product.price;

            PeakPower = vapes.peak_power;
        }

        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new RelayCommand(obj =>
                  {
                      ProductModel.delete(ProductId, _sectionId);
                      CurrentVM.CurrentVM = new AdministratorCatalogVM(ProductModel.getProducts(4), "Вейпы", CurrentVM);
                  }));
            }
        }

        private RelayCommand updateCommand;
        public RelayCommand UpdateCommand
        {
            get
            {
                return updateCommand ??
                  (updateCommand = new RelayCommand(obj =>
                  {
                      ProductModel.updateVapes(ProductId, Name, Price, PeakPower);
                  }));
            }
        }
    }
}
