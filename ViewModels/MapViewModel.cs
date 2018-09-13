using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiMobile.Contracts.Extensions;
using TaxiMobile.Contracts.Services;
using TaxiMobile.Contracts.Services.Other;
using TaxiMobile.Model;
using TaxiMobile.ViewModels;

namespace TaxiMobile.ViewModels
{
    public class MapViewModel : BaseViewModel
    {
        private readonly ITaxiDataService _taxiDataService;
        private readonly IDriverDataService _driverDataService;
        private readonly ILocationService _locationService;
        private ObservableCollection<Taxi> _taxiList;
        private decimal _range;
        private Taxi _selectedTaxi;

        public MapViewModel(ITaxiDataService taxiDataService,IDriverDataService driverDataService,ILocationService locationService, INavigationService navigationService, IDialogService dialogService)
            :base(navigationService, dialogService)
        {
            _taxiDataService = taxiDataService;

            _driverDataService = driverDataService;

            _locationService = locationService;
        }

        public void Init(decimal range)
        {
            _range = range;
        }


        protected async Task InitializeAsync()
        {
           // var location = await _locationService.GetUserLocation();
          //  TaxiList=(await _taxiDataService.GetTaxiList(Range,location)).ToObservableCollection();
        }

        public decimal Range
        {
            get { return _range; }
            set
            {
                _range = value;
            }
        }

        public ObservableCollection<Taxi> TaxiList
        {
            get { return _taxiList; }
            set
            {
                _taxiList = value;
            }
        }

        public Taxi SelectedTaxi
        {
            get { return _selectedTaxi; }
            set
            {
                _selectedTaxi = value;
            }
        }

    }
}
