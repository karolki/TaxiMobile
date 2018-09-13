using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaxiMobile.Contracts.Services.Other;

namespace TaxiMobile.ViewModels
{
    public class StartViewModel : BaseViewModel
    {
        public StartViewModel(INavigationService navigationService,IDialogService dialogService,
           MenuViewModel menuViewModel)
           : base(navigationService, dialogService)
        {
            _menuViewModel = menuViewModel;
        }

        private MenuViewModel _menuViewModel;
        public MenuViewModel MenuViewModel
        {
            get => _menuViewModel;
            set
            {
                _menuViewModel = value;
                OnPropertyChanged();
            }
        }
        public override async Task InitializeAsync(object data)
        {
            await Task.WhenAll
            (
                _menuViewModel.InitializeAsync(data),
                _navigationService.NavigateToAsync<MainViewModel>()
            );
        }
    }

}
