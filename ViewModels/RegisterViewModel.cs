using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaxiMobile.Contracts.Services;
using TaxiMobile.Contracts.Services.Other;
using TaxiMobile.Model;
using TaxiMobile.Utility;
using Xamarin.Forms;

namespace TaxiMobile.ViewModels
{
    public class RegisterViewModel :BaseViewModel
    {
        private IDriverDataService _driverDataService;

        public RegisterViewModel(
            IDriverDataService driverDataService,
            INavigationService navigationService,IDialogService dialogService)
            :base(navigationService, dialogService )
        {
            _driverDataService = driverDataService;
            Driver = new Driver();
        }

        private Driver _driver;
        public Driver Driver
        {
            get => _driver;
            set
            {
                _driver = value;
                OnPropertyChanged();
            }
        }
     

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        private string _passwordConfirmation;
        public string PasswordConfirmation
        {
            get => _passwordConfirmation;
            set
            {
                _passwordConfirmation = value;
                OnPropertyChanged();
            }
        }

        public ICommand RegisterCommand => new Command(OnRegister);

        private async void OnRegister(object obj)
        {

            if (CheckEmpty() && Password==PasswordConfirmation)
            {
                var result = _driverDataService.Register(Driver,Password);

                if (result)
                {
                    Driver = new Driver();
                    Password = "";
                    PasswordConfirmation = "";
                    _dialogService.ShowToast("Registration complete, u can log in!");
                    AppContainer.Resolve<MainViewModel>().Init();
                    _navigationService.NavigateBackAsync();
                }
                else
                {
                   await _dialogService.ShowDialog("Unexpected error", "ERROR", "OK");
                }
            }
            else
            {
                  await _dialogService.ShowDialog("Properties can't be empty!", "ERROR", "OK");
            }
        }

       

        private bool CheckEmpty()
        {
            return ! ( string.IsNullOrWhiteSpace(Driver.Drv_Name) ||
                string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(Driver.Drv_Surname)|| string.IsNullOrWhiteSpace(PasswordConfirmation)) ;
        }


    }
}
