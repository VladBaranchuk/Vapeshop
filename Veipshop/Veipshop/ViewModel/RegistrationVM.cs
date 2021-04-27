using Veipshop.Service;

namespace Veipshop.ViewModel
{
    public class RegistrationVM : ViewModelBase
    {
        private LoginVM _loginVM;
        private SignupVM _signupVM;

        public RegistrationVM(ViewModelBase mainWindowVM)
        {
            _loginVM = new LoginVM(mainWindowVM);
            _signupVM = new SignupVM(mainWindowVM);

            CurrentVM = _loginVM;
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
                OnPropertyChanged();
            }
        }

        private RelayCommand loginCommand;
        public RelayCommand LoginCommand
        {
            get
            {
                return loginCommand ??
                  (loginCommand = new RelayCommand(obj =>
                  {
                      CurrentVM = _loginVM;
                  }));
            }
        }

        private RelayCommand signupCommand;
        public RelayCommand SignupCommand
        {
            get
            {
                return signupCommand ??
                  (signupCommand = new RelayCommand(obj =>
                  {
                      CurrentVM = _signupVM;
                  }));
            }
        }



    }
}
