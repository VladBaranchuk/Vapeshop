using Veipshop.Model;
using System.Windows;
using System.Collections.ObjectModel;
using Veipshop.Service;
using System.Text.RegularExpressions;
using System;

namespace Veipshop.ViewModel
{
    public class SearchVM : ViewModelBase
    {
        public Regex RegexFromAndTo = new Regex("^\\d{1,}$");

        private bool _BoolFrom = false;
        private bool _BoolTo = false;
        private bool _BoolSection = false;
        private bool _BoolBrand = false;

        private int from;
        public int From
        {
            get { return from; }
            set
            {
                from = value;
                OnPropertyChanged("From");
            }
        }

        private int to = 10000;
        public int To
        {
            get { return to; }
            set
            {
                to = value;
                OnPropertyChanged("To");
            }
        }

        private int selectSection;
        public int SelectSection
        {
            get { return selectSection; }
            set
            {
                selectSection = value;
                OnPropertyChanged("SelectSection");
            }
        }

        private int selectBrand;
        public int SelectBrand
        {
            get { return selectBrand; }
            set
            {
                selectBrand = value;
                OnPropertyChanged("SelectBrand");
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

        private string searchString = "";
        public string SearchString
        {
            get { return searchString; }
            set
            {
                searchString = value;
                OnPropertyChanged("SearchString");
            }
        }

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

        public ObservableCollection<Section> Sections { get; set; }
        public ObservableCollection<Brand> Brands { get; set; }

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

        public SearchVM(ViewModelBase currentVM)
        {
            Sections = SearchModel.getSection();
            Brands = SearchModel.getBrand();

            CurrentVM = currentVM as AppUserVM;
        }

        private RelayCommand searchCommand;
        public RelayCommand SearchCommand
        {
            get
            {
                return searchCommand ??
                  (searchCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (RegexFromAndTo.IsMatch(From.ToString()))
                          {
                              _BoolFrom = true;
                          }

                          if (RegexFromAndTo.IsMatch(To.ToString()))
                          {
                              _BoolTo = true;
                          }

                          if (!_BoolFrom)
                          {
                              From = 0;
                              _BoolFrom = true;
                          }

                          if (!_BoolTo)
                          {
                              To = 999999;
                              _BoolTo = true;
                          }

                          if(_BoolFrom && _BoolTo)
                          {
                              Products = SearchModel.getSearch(From, To, SelectSection, SelectBrand, SearchString);
                          }
                      }
                      catch(Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
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
                          else if (Product.section_id == 2)
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
