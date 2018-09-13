using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaxiMobile.Const;
using TaxiMobile.Contracts.Services;
using TaxiMobile.Contracts.Services.Other;
using Xamarin.Forms;

namespace TaxiMobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private IDriverDataService _driverDataService;

        public LoginViewModel(IDriverDataService driverDataService, INavigationService navigationService, IDialogService dialogService)
            :base(navigationService,dialogService)
        {
            _driverDataService = driverDataService;
        }


        private string _identString = "";
        public string IdentString
        {
            get => _identString;
            set
            {
                _identString = value;
                OnPropertyChanged();
            }
        }

        private string _passwordString = "";
        public string PasswordString
        {
            get => _passwordString;
            set
            {
                _passwordString = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand => new Command(OnLogin);

        private async void OnLogin(object obj)
        {
            if (string.IsNullOrWhiteSpace(IdentString) || string.IsNullOrWhiteSpace(PasswordString))
            {
                 await _dialogService.ShowDialog(string.Format("Identity and password can't be empty!"), "ERROR", "OK");
            }
            else
            {
                 _driverDataService.Login(IdentString, PasswordString);

                if (_driverDataService.ActiveDriver == null)
                {
                     await _dialogService.ShowDialog(string.Format("Incorrect passwor :("), "WRONG", "OK");
                }
                else
                {
                    MessagingCenter.Send(this, MessageConstants.IsLoggedIn, true);
                    await _navigationService.NavigateToAsync<MainViewModel>();
                    _dialogService.ShowToast($"Welcome {_driverDataService.ActiveDriver.Drv_Name}!");
                }
            }
        }

        public ICommand RegisterCommand => new Command(OnRegister);

        private async void OnRegister(object obj)
        {
            await _navigationService.NavigateToAsync<RegisterViewModel>();
        }


    }
}
