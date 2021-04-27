using Veipshop.Model;
using System.Collections.ObjectModel;
using Veipshop.Service;

namespace Veipshop.ViewModel
{
    public class CatalogVM : ViewModelBase
    {
        public ObservableCollection<Products> Products { get; set; }

        //private AppUserVM appUserVM;
        //public AppUserVM AppUserVM
        //{
        //    get { return appUserVM; }
        //    set
        //    {
        //        appUserVM = value;
        //        OnPropertyChanged("AppUserVM");
        //    }
        //}

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

        private AppUserVM _currentVM;
        public AppUserVM CurrentVM
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

        public CatalogVM(ObservableCollection<Products> Section, string SectionNameValue, ViewModelBase currentVM)
        {
            Products = Section;

            SectionName = SectionNameValue;

            CurrentVM = currentVM as AppUserVM;
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
                      if(Product != null)
                      {

                          BasketModel.setOrder(Product.product_id);
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
                              CurrentVM.CurrentVM = new PodVM(Product);
                          }
                          else if(Product.section_id == 2)
                          {
                              CurrentVM.CurrentVM = new THSVM(Product);
                          }
                          else if (Product.section_id == 3)
                          {
                              CurrentVM.CurrentVM = new VapingLiquidVM(Product);
                          }
                          else if (Product.section_id == 4)
                          {
                              CurrentVM.CurrentVM = new VapesVM(Product);
                          }
                      }
                  }));
            }
        }

    }
}
