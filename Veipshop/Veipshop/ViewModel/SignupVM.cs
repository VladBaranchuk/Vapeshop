using Veipshop.Model;
using Veipshop.Service;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using System;
using System.Windows.Media;
using System.Windows.Controls;

namespace Veipshop.ViewModel
{
    public class SignupVM : ViewModelBase
    {
        public Regex RegexName = new Regex("^([А-Я]|[A-Z])([а-я]|[a-z]){1,19}$");
        public Regex RegexSurname = new Regex("^([А-Я]|[A-Z])([а-я]|[a-z]){1,19}$");
        public Regex RegexLogin = new Regex(@"(\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,6})");
        public Regex RegexPassword = new Regex(@"(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])[0-9a-zA-Z!@#$%^&*]{9,}");

        public CroppedBitmap Image;

        private bool _BoolName = false;
        private bool _BoolSurname = false;
        private bool _BoolLogin = false;
        private bool _BoolPassword = false;

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

        private string login;
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        private string confirmPassword;
        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set
            {
                confirmPassword = value;
                OnPropertyChanged("ConfirmPassword");
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

        public SignupVM(ViewModelBase mainWindowVM)
        {
            MainWindowVM = mainWindowVM as MainWinowVM;
        }

        private RelayCommand signupCommand;
        public RelayCommand SignupCommand
        {
            get
            {
                return signupCommand ??
                  (signupCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (RegexName.IsMatch(Name))
                          {
                              _BoolName = true;
                          }
                          else
                          {
                              MessageBox.Show("Поле Имя не должно быть пустым и должно содержать только буквы кириллического либо латинского алфавита");
                          }

                          if (RegexSurname.IsMatch(Surname))
                          {
                              _BoolSurname = true;
                          }
                          else
                          {
                              MessageBox.Show("Поле Фамилия не должно быть пустым и должно содержать только буквы кириллического либо латинского алфавита");
                          }

                          if (RegexLogin.IsMatch(Login))
                          {
                              if (UserModel.checkLogin(Login))
                              {
                                  _BoolLogin = true;
                              }
                              else
                              {
                                  MessageBox.Show("Такой Логин уже существует");
                              }
                              
                          }
                          else
                          {
                              MessageBox.Show("Поле Логин не должно быть пустым и должно содержать имя почты");
                          }

                          if (RegexPassword.IsMatch(Password))
                          {
                              if (RegexPassword.IsMatch(ConfirmPassword))
                              {
                                  if (Password == ConfirmPassword)
                                  {
                                        _BoolPassword = true;
                                  }
                                  else
                                  {
                                      MessageBox.Show("Поле Повторить Пароль и Пароль не совпадают");
                                  }
                              }
                              else
                              {
                                  MessageBox.Show("Поле Повторите Пароль не должно быть пустым и должно содержать не менее 9 символов включая буквы латинского алфавита в верхнем и нижнем регистре, и числа");
                              }
                          }
                          else
                          {
                              MessageBox.Show("Поле Пароль не должно быть пустым и должно содержать не менее 9 символов включая спецсимволы, буквы латинского алфавита, числа");
                          }

                          if (_BoolName && _BoolSurname && _BoolLogin && _BoolPassword)
                          {
                              if (Image != null)
                              {
      
                                  BitmapEncoder encoder = new PngBitmapEncoder(); // Создаем новый образ кодировщика
                                  encoder.Frames.Add(BitmapFrame.Create(Image)); // кодируем наше обрезанное изображение в png и далее ниже его сохраняем

                                  using (var fileStream = new System.IO.FileStream(Environment.CurrentDirectory + "/Images/Profiles/" + Name + "_" + Surname + ".png", System.IO.FileMode.Create))
                                  {   
                                      encoder.Save(fileStream);
                                  }
                              }

                              UserModel.Registration(Name, Surname, Login, Password);

                              UserModel.Autorization(Login);

                              MainWindowVM.CurrentVM = new AppUserVM(MainWindowVM);
                          }

                      }
                      catch(Exception ex)
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
                          openFileDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|Portable Network Graphic (*.png)|*.png";
                          if (openFileDialog.ShowDialog() == true)
                          {
                              Uri uri = new Uri(openFileDialog.FileName); // Получаем ссылку на файл (картинку)

                              Image croppedImage = new Image();
                              BitmapImage bitmap = new BitmapImage(uri); // Создаем новый образ битового изображения
                              Image = new CroppedBitmap(
                                 bitmap,
                                 new Int32Rect((bitmap.PixelWidth - 600) / 2, (bitmap.PixelHeight - 600) / 2, 600, 600));       // Выбираем настройки обрезки
                              Photo = new ImageBrush(Image);
                          }
                      }
                      catch
                      {
                          MessageBox.Show("Изображение должно быть меньше 600х600 пикселей");
                      }
                  }));
            }
        }
    }
}
