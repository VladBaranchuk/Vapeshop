using Veipshop.Model;
using Veipshop.Service;
using System.Text.RegularExpressions;
using System.Windows;
using System;
using Veipshop.ViewModel.Administrator;

namespace Veipshop.ViewModel
{
    public class LoginVM : ViewModelBase
    {
        public Regex RegexLogin = new Regex(@"(\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,6})");
        public Regex RegexPassword = new Regex(@"(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])[0-9a-zA-Z!@#$%^&*]{9,}");

        private bool _BoolLogin = false;
        private bool _BoolPassword = false;

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

        public LoginVM(ViewModelBase mainWindowVM)
        {
            MainWindowVM = mainWindowVM as MainWinowVM;
        }

        private RelayCommand loginCommand;
        public RelayCommand LoginCommand
        {
            get
            {
                return loginCommand ??
                  (loginCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (RegexLogin.IsMatch(Login))
                          {
                              _BoolLogin = true;
                          }
                          else
                          {
                              MessageBox.Show("Поле Логин не должно быть пустым и должно содержать имя почты");
                          }

                          if (RegexPassword.IsMatch(Password))
                          {

                              if (UserModel.CheckLogin(Login) && UserModel.CheckPassword(Login, Password))
                              {
                                  _BoolPassword = true;
                              }
                              else
                              {
                                  MessageBox.Show("Не верный логин или пароль");
                              }
                          }
                          else
                          {
                              MessageBox.Show("Поле Повторите Пароль не должно быть пустым и должно содержать не менее 9 символов включая буквы латинского алфавита в верхнем и нижнем регистре, и числа");
                          }

                          if (_BoolLogin && _BoolPassword)
                          {

                              UserModel.Autorization(Login);

                              if(Login == "administrator@gmail.com")
                              {
                                  MainWindowVM.CurrentVM = new AppAdministratorVM(MainWindowVM);
                              }
                              else
                              {
                                  MainWindowVM.CurrentVM = new AppUserVM(MainWindowVM);
                              }                   
                          }
                      }
                      catch(Exception ex)
                      {
                          MessageBox.Show(ex.Message);

                      }
                  }));
            }
        }
        
    }
}
