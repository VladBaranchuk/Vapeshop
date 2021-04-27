using Veipshop.Model;
using Veipshop.ViewModel.Administrator;

namespace Veipshop.ViewModel
{
    public class MainWinowVM : ViewModelBase
    {
        private RegistrationVM _registrationVM;

        public MainWinowVM()
        {
            _registrationVM = new RegistrationVM(this);

            CurrentVM = _registrationVM;
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

    }
}
