using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using TaxiMobile.Contracts.Extensions;
using TaxiMobile.Contracts.Services;
using TaxiMobile.Contracts.Services.Other;
using TaxiMobile.Model;
using TaxiMobile.Services;
using Xamarin.Forms;

namespace TaxiMobile.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        IDriverDataService _driverDataService;

        public ICommand DriverTappedCommand => new Command<Driver>(OnDriverTapped);

        private async void OnDriverTapped(Driver obj)
        {
            await _navigationService.NavigateToAsync<DriverDetailViewModel>(obj);
        }
        private ObservableCollection<Driver> _driverCollection;
        public ObservableCollection<Driver> DriverCollection
        {
            get => _driverCollection;
            set
            {
                _driverCollection = value;
                OnPropertyChanged();
            }
        }

        private string _text;
        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel(INavigationService navigationService, IDialogService dialogService, IDriverDataService driverDataService)
            : base(navigationService, dialogService)
        {
            _driverDataService = driverDataService;
            Init();  
            //DriverCollection = new ObservableCollection<Driver>()
            //{
            //    new Driver()
            //    {
            //        Drv_Name="tomas",
            //        Drv_Surname="meh",
            //        Distance=1200,
            //        Drv_Phone="124 124 324"
            //    }
            //};
        }

        public  void Init()
        {
            var a = (_driverDataService.GetActiveDrivers());
            foreach(var driver in a)
            {
                driver.Distance = LocalizationService.Distance(driver.Drv_Latitude, driver.Drv_Longitude);
            }
            var sorted = a.OrderBy(x => x.Distance);
            DriverCollection = sorted.ToObservableCollection();
        }
    }
}
