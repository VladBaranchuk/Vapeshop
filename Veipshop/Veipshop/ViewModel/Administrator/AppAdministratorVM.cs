using System.Windows.Media;
using Veipshop.Model;
using Veipshop.Service;

namespace Veipshop.ViewModel.Administrator
{
    public class AppAdministratorVM : ViewModelBase
    {
        private ImageBrush photo;
        public ImageBrush Photo
        {
            get { return photo; }
            set
            {
                photo = value;
                OnPropertyChanged("Photo");
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

        private string surname;
        public string Surname
        {
            get { return surname; }
            set
            {
                surname = value;
                OnPropertyChanged("Surname");
            }
        }

        private ViewModelBase _currentVM;
        public ViewModelBase CurrentVM
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

        private MainWinowVM _mainWindowVM;
        public MainWinowVM MainWindowVM
        {
            get => _mainWindowVM;
            set
            {
                if (_mainWindowVM == value)
                {
                    return;
                }
                _mainWindowVM = value;
                OnPropertyChanged("MainWindowVM");
            }
        }

        private AdministratorCatalogVM _Catalog;

        public AppAdministratorVM(ViewModelBase mainWindowVM)
        {
            Name = UserModel.Name;
            Surname = UserModel.Surname;
            Photo = UserModel.getPhoto(Name, Surname);

            _Catalog = new AdministratorCatalogVM(ProductModel.getProducts(1), "POD-системы", this);

            CurrentVM = _Catalog;
            MainWindowVM = mainWindowVM as MainWinowVM;
        }

        private RelayCommand podCommand;
        public RelayCommand PodCommand
        {
            get
            {
                return podCommand ??
                  (podCommand = new RelayCommand(obj =>
                  {
                      CurrentVM = new AdministratorCatalogVM(ProductModel.getProducts(1), "POD-системы", this);
                  }));
            }
        }

        private RelayCommand thsCommand;
        public RelayCommand THSCommand
        {
            get
            {
                return thsCommand ??
                  (thsCommand = new RelayCommand(obj =>
                  {
                      CurrentVM = new AdministratorCatalogVM(ProductModel.getProducts(2), "Системы нагревания табака", this);
                  }));
            }
        }

        private RelayCommand vapingLiquidCommand;
        public RelayCommand VapingLiquidCommand
        {
            get
            {
                return vapingLiquidCommand ??
                  (vapingLiquidCommand = new RelayCommand(obj =>
                  {
                      CurrentVM = new AdministratorCatalogVM(ProductModel.getProducts(3), "Жидкость для вейпа", this);
                  }));
            }
        }

        private RelayCommand vapesCommand;
        public RelayCommand VapesCommand
        {
            get
            {
                return vapesCommand ??
                  (vapesCommand = new RelayCommand(obj =>
                  {
                      CurrentVM = new AdministratorCatalogVM(ProductModel.getProducts(4), "Вейпы", this);
                  }));
            }
        }

        private RelayCommand newProductCommand;
        public RelayCommand NewProductCommand
        {
            get
            {
                return newProductCommand ??
                  (newProductCommand = new RelayCommand(obj =>
                  {
                      CurrentVM = new AdministratorAddProductVM();
                  }));
            }
        }

        private RelayCommand ordersCommand;
        public RelayCommand OrdersCommand
        {
            get
            {
                return ordersCommand ??
                  (ordersCommand = new RelayCommand(obj =>
                  {
                      CurrentVM = new AdministratorOrdersVM();
                  }));
            }
        }

        private RelayCommand searchCommand;
        public RelayCommand SearchCommand
        {
            get
            {
                return searchCommand ??
                  (searchCommand = new RelayCommand(obj =>
                  {
                      CurrentVM = new AdministratorSearchVM(this);
                  }));
            }
        }

        private RelayCommand exitCommand;
        public RelayCommand ExitCommand
        {
            get
            {
                return exitCommand ??
                  (exitCommand = new RelayCommand(obj =>
                  {
                      MainWindowVM.CurrentVM = new RegistrationVM(MainWindowVM);
                  }));
            }
        }
    }
}
