using Veipshop.Model;
using Veipshop.Service;

namespace Veipshop.ViewModel.Administrator
{
    public class AdministratorVapingLiquidVM : ViewModelBase
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

        private Vaping_liquid vapingLiquid;

        private int? _sectionId;

        public AdministratorVapingLiquidVM(Products product, ViewModelBase currentVM)
        {
            CurrentVM = currentVM as AppAdministratorVM;

            _sectionId = product.section_id;

            vapingLiquid = ProductModel.ProductToVapingLiquid(product);

            ProductId = product.product_id;
            Name = product.name;
            Price = product.price;

            Taste = vapingLiquid.taste;
            Volume = vapingLiquid.volume;
            Strong = vapingLiquid.strong;
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
                      CurrentVM.CurrentVM = new AdministratorCatalogVM(ProductModel.getProducts(3), "Жидкость для вейпа", CurrentVM);
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
                      ProductModel.updateVapingLiquid(ProductId, Name, Price, Taste, Volume, Strong);
                  }));
            }
        }
    }
}
