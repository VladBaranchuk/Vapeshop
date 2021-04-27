using Veipshop.Model;
using System.Collections.ObjectModel;
using Veipshop.Service;

namespace Veipshop.ViewModel.Administrator
{
    public class AdministratorCatalogVM : ViewModelBase
    {
        private ObservableCollection<Products> products;
        public ObservableCollection<Products> Products
        {
            get { return products; }
            set
            {
                products = value;
                OnPropertyChanged("Products");
            }
        }

        private Products selectedProduct;
        public Products SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                OnPropertyChanged("SelectedProduct");
            }
        }

        private string sectionName;
        public string SectionName
        {
            get { return sectionName; }
            set
            {
                sectionName = value;
                OnPropertyChanged("SectionName");
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

        public AdministratorCatalogVM(ObservableCollection<Products> Section, string SectionNameValue, ViewModelBase currentVM)
        {
            Products = Section;

            SectionName = SectionNameValue;

            CurrentVM = currentVM as AppAdministratorVM;
        }

        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new RelayCommand(obj =>
                  {
                      Products Product = obj as Products;
                      if (Product != null)
                      {
                          ProductModel.delete(Product.product_id, Product.section_id);
                          Products.Remove(Product);
                      }
                  }));
            }
        }

        private RelayCommand clickCommand;
        public RelayCommand ClickCommand
        {
            get
            {
                return clickCommand ??
                  (clickCommand = new RelayCommand(obj =>
                  {
                      Products Product = obj as Products;

                      if (Product != null)
                      {
                          if (Product.section_id == 1)
                          {
                              CurrentVM.CurrentVM = new AdministratorPodVM(Product, CurrentVM);
                          }
                          else if (Product.section_id == 2)
                          {
                              CurrentVM.CurrentVM = new AdministratorTHSVM(Product, CurrentVM);
                          }
                          else if (Product.section_id == 3)
                          {
                              CurrentVM.CurrentVM = new AdministratorVapingLiquidVM(Product, CurrentVM);
                          }
                          else if (Product.section_id == 4)
                          {
                              CurrentVM.CurrentVM = new AdministratorVapesVM(Product, CurrentVM);
                          }
                      }
                  }));
            }
        }
    }
}
