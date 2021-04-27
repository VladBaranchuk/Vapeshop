using Veipshop.Model;
using Veipshop.Service;

namespace Veipshop.ViewModel.Administrator
{
    public class AdministratorPodVM : ViewModelBase
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

        private Pod pod;

        private int? _sectionId;

        public AdministratorPodVM(Products product, ViewModelBase currentVM)
        {
            CurrentVM = currentVM as AppAdministratorVM;

            _sectionId = product.section_id;

            pod = ProductModel.ProductToPod(product);

            ProductId = product.product_id;
            Name = product.name;
            Price = product.price;

            BatteryCapacity = pod.battery_capacity;
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
                      CurrentVM.CurrentVM = new AdministratorCatalogVM(ProductModel.getProducts(1), "POD-системы", CurrentVM);
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
                      ProductModel.updatePod(ProductId, Name, Price, BatteryCapacity);
                  }));
            }
        }
    }
}
