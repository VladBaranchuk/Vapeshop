using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Veipshop.Model;
using Veipshop.Service;
using System.Windows;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace Veipshop.ViewModel.Administrator
{
    public class AdministratorAddProductVM : ViewModelBase
    {
        public ObservableCollection<Section> Sections { get; set; }
        public ObservableCollection<Brand> Brands { get; set; }
        public ObservableCollection<Manufacturer> Manufacturers { get; set; }
        public ObservableCollection<Country> Countries { get; set; }

        private bool _BoolName = false;
        private bool _BoolPrice = false;
        private bool _BoolSection = false;
        private bool _BoolBrand = false;
        private bool _BoolManufacturer = false;
        private bool _BoolCountry = false;
        private bool _BoolPhoto = false;

        public Regex RegexName = new Regex("^([А-Я]|[A-Z]|[а-я]|[a-z]|[0-9]|.){1,100}$");
        public Regex RegexPrice = new Regex(@"(\d){1,7}");

        public CroppedBitmap Image;

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

        private int selectManufacturer;
        public int SelectManufacturer
        {
            get { return selectManufacturer; }
            set
            {
                selectManufacturer = value;
                OnPropertyChanged("SelectManufacturer");
            }
        }

        private int selectCountry;
        public int SelectCountry
        {
            get { return selectCountry; }
            set
            {
                selectCountry = value;
                OnPropertyChanged("SelectCountry");
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

        public AdministratorAddProductVM()
        {
            Sections = SearchModel.getSections();
            Brands = SearchModel.getBrands();
            Manufacturers = SearchModel.getManufacturers();
            Countries = SearchModel.getCountries();
        }


        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (RegexName.IsMatch(Name))
                          {
                              _BoolName = true;
                          }
                          else
                          {
                              MessageBox.Show("Поле Название не должно быть пустым и должно содержать только буквы кириллического либо латинского алфавита");
                          }

                          if (RegexPrice.IsMatch(Price.ToString()))
                          {
                              _BoolPrice = true;
                          }
                          else
                          {
                              MessageBox.Show("Поле Цена не должно быть пустым и должно содержать только цифры");
                          }

                          if (SelectSection != 0)
                          {
                              _BoolSection = true;
                          }
                          else
                          {
                              MessageBox.Show("Поле Типа не должно быть пустым");
                          }

                          if (SelectBrand != 0)
                          {
                              _BoolBrand = true;
                          }
                          else
                          {
                              MessageBox.Show("Поле Бренда не должно быть пустым");
                          }

                          if (SelectManufacturer != 0)
                          {
                              _BoolManufacturer = true;
                          }
                          else
                          {
                              MessageBox.Show("Поле Производителя не должно быть пустым");
                          }
 
                          if (SelectCountry != 0)
                          {
                              _BoolCountry = true;
                          }
                          else
                          {
                              MessageBox.Show("Поле Страны не должно быть пустым");
                          }

                          if (Photo != null)
                          {
                              _BoolPhoto = true;
                          }
                          else
                          {
                              MessageBox.Show("Поле Изображения не должно быть пустым");
                          }


                          if (_BoolName && _BoolPrice && _BoolSection && _BoolBrand && _BoolManufacturer && _BoolCountry && _BoolPhoto)
                          {

                              int Id = ProductModel.addProduct(Name, Price, SelectSection, SelectBrand, SelectManufacturer, SelectCountry);


                              if (Image != null)
                              {

                                  BitmapEncoder encoder = new PngBitmapEncoder(); // Создаем новый образ кодировщика
                                  encoder.Frames.Add(BitmapFrame.Create(Image)); // кодируем наше обрезанное изображение в png и далее ниже его сохраняем

                                  using (var fileStream = new System.IO.FileStream(Environment.CurrentDirectory + "/Images/Products/" + Id + ".png", System.IO.FileMode.Create))
                                  {
                                      encoder.Save(fileStream);
                                  }
                              }

                              Name = "";
                              Price = null;
                              SelectBrand = 0;
                              SelectCountry = 0;
                              SelectManufacturer = 0;
                              SelectSection = 0;
                              Photo = null;
                          }

                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show("Отсутствует подключение к базе данных,\n проверьте соединение на сервере или " + ex.Message);
                      }
                  }));
            }
        }

        private RelayCommand photoCommand;
        public RelayCommand PhotoCommand
        {
            get
            {
                return photoCommand ??
                  (photoCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          OpenFileDialog openFileDialog = new OpenFileDialog();
                          openFileDialog.Filter = "Portable Network Graphic (*.png)|*.png";
                          if (openFileDialog.ShowDialog() == true)
                          {
                              Uri uri = new Uri(openFileDialog.FileName); // Получаем ссылку на файл (картинку)

                              Image croppedImage = new Image();
                              BitmapImage bitmap = new BitmapImage(uri); // Создаем новый образ битового изображения
                              Image = new CroppedBitmap(
                                 bitmap,
                                 new Int32Rect((bitmap.PixelWidth - 200) / 2, (bitmap.PixelHeight - 200) / 2, 200, 200));       // Выбираем настройки обрезки
                              Photo = new ImageBrush(Image);
                          }
                      }
                      catch
                      {
                          MessageBox.Show("Изображение должно быть меньше 200х200 пикселей");
                      }
                  }));
            }
        }
    }
}
