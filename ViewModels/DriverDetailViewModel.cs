using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public class DriverDetailViewModel : BaseViewModel
    {
        private IDriverDataService _driverDataService;
        private IPhoneService _phoneService;
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

        private string _author;
        public string Author
        {
            get => _author;
            set
            {
                _author = value;
                OnPropertyChanged();
            }
        }

        private string _commentDescription;
        public string CommentDescription
        {
            get => _commentDescription;
            set
            {
                _commentDescription = value;
                OnPropertyChanged();
            }
        }

        private decimal _rating;
        public decimal Rating
        {
            get => _rating;
            set
            {
                _rating = value;
                OnPropertyChanged();
            }
        }

        public ICommand PhoneCommand => new Command(OnPhone);
 
        private void OnPhone(object obj)
        {
            try
            {
                _phoneService.MakePhoneCall(Driver.Drv_Phone);
            }
            catch(Exception e)
            {
                _dialogService.ShowDialog(e.Message, "ERROR", "OK");
            }
        }

        public ICommand CommentCommand => new Command(OnComent);

        private void OnComent(object obj)
        {
            var comment =
                new Opinion()
                {
                    Opi_Date = DateTime.Now,
                    Opi_Description = CommentDescription,
                    Opi_Person = Author,
                    Opi_Rating = Rating,
                    Driver = Driver
                };
            var result= _driverDataService.AddOpinion(comment);
            Author = "";
            CommentDescription = "";
            Rating = 0;
            if (result) _dialogService.ShowToast("Comment added!");
            Driver.OpinionList.Add(comment);
            AppContainer.Resolve<MainViewModel>().Init();
            _navigationService.NavigateBackAsync();
        }

        public DriverDetailViewModel(INavigationService navigationService 
            ,IDriverDataService driverDataService, IDialogService dialogService,IPhoneService phoneService) 
            : base(navigationService, dialogService)
        {
            _phoneService = phoneService;
            _driverDataService = driverDataService;
        }

        public override async Task InitializeAsync(object data)
        {
            Driver = (data as Driver);
            _commentDescription = "";
            _author = "";
        }
    }
}
