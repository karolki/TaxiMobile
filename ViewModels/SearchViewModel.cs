using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiMobile.Contracts.Services;
using TaxiMobile.Contracts.Services.Other;
using Xamarin.Forms;

namespace TaxiMobile.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
        
        private readonly IDriverDataService _driverDataService;
        private decimal _range;
        private string _distanceString;
        public SearchViewModel(IDriverDataService driverDataService, INavigationService navigationService, IDialogService dialogService)
            :base(navigationService, dialogService)
        {
            _driverDataService = driverDataService;
        }

        public decimal Range
        {
            get { return _range; }
            set
            {
                _range = value;
                DistanceString = Range.ToString("0 000.0") + " km";
            }
        }

        public string DistanceString
        {
            get { return _distanceString; }
            set
            {
                _distanceString = value;
            }
        }


        public Command<decimal> ShowJourneyDetailsCommand
        {
            get
            {
                return new Command<decimal>(selectedJourney =>
                {
                   // ShowViewModel<MapViewModel>
                   // (new { range = Range });
                });
            }
        }
    }
}
