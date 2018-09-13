using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using TaxiMobile.Const;
using TaxiMobile.Contracts.Services;
using TaxiMobile.Contracts.Services.Other;
using TaxiMobile.Models;
using TaxiMobile.Services;
using Xamarin.Forms;

namespace TaxiMobile.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        private IDriverDataService _driverDataService;

        public string WelcomeText => "Hello in TaxiMobile!";

        private ObservableCollection<MainMenuItem> _menuItems;
        public ObservableCollection<MainMenuItem> MenuItems
        {
            get => _menuItems;
            set
            {
                _menuItems = value;
                OnPropertyChanged();
            }
        }

        private bool _isUserLoggedIn;

        public bool IsUserLoggedIn
        {
            get => _isUserLoggedIn;
            set
            {
                _isUserLoggedIn = value;
                OnPropertyChanged();
            }
        }


        public ICommand MenuItemTappedCommand => new Command(OnMenuItemTapped);

        private void OnMenuItemTapped(object obj)
        {
            var menuItem = ((obj as ItemTappedEventArgs)?.Item as MainMenuItem);

            if (menuItem != null && menuItem.MenuText == "Log out")
            {
                _driverDataService.Logout();
                _navigationService.ClearBackStack();
            }
            if (menuItem != null && menuItem.MenuItemType == MenuItemType.Map)
            {
                try
                {
                    _driverDataService.ActiveDriver.Drv_Latitude = LocalizationService.Lat;
                    _driverDataService.ActiveDriver.Drv_Longitude = LocalizationService.Lng;
                    _driverDataService.ActiveDriver.Drv_Timing = DateTime.Now;
                    return;
                }
                catch(Exception e)
                {

                }
            }

            var type = menuItem?.ViewModelToLoad;
            _navigationService.NavigateToAsync(type);
        }

        public MenuViewModel(INavigationService navigationService,IDriverDataService driverDataService, IDialogService dialogService)
            :base(navigationService,dialogService)
        {
            MessagingCenter.Subscribe<LoginViewModel, bool>
                (this, MessageConstants.IsLoggedIn,
                (loginViewModel, isLoggedIn) => SetIsLoggedIn(isLoggedIn)
                );
            _driverDataService = driverDataService;
            MenuItems = new ObservableCollection<MainMenuItem>();
            LoadMenuItems();
        }

        private void SetIsLoggedIn(bool isLoggedIn)
        {
            IsUserLoggedIn = isLoggedIn;
            SetMenu();
        }

        private void SetMenu()
        {
            foreach(var item in MenuItems)
            {
                if(item.MenuItemType==MenuItemType.Login)
                {
                    item.MenuText = IsUserLoggedIn ? "Log out" : "Log in";
                }
                else if(item.MenuItemType==MenuItemType.Map)
                {
                    item.IsVisible = IsUserLoggedIn;
                }
            }
        }

        private void LoadMenuItems()
        {
            MenuItems.Add(new MainMenuItem
            {
                MenuText = "Home",
                ViewModelToLoad = typeof(MainViewModel),
                MenuItemType = MenuItemType.Home,
                IsVisible = true
            });

            MenuItems.Add(new MainMenuItem
            {
                MenuText = "Search driver",
                ViewModelToLoad = typeof(SearchViewModel),
                MenuItemType = MenuItemType.Search,
                IsVisible = true
            });

            MenuItems.Add(new MainMenuItem
            {
                MenuText = "Log in",
                ViewModelToLoad = typeof(LoginViewModel),
                MenuItemType = MenuItemType.Login,
                IsVisible = true
            });

            MenuItems.Add(new MainMenuItem
            {
                MenuText = "Show yourself",
                ViewModelToLoad = typeof(SearchViewModel),
                MenuItemType = MenuItemType.Map,
                IsVisible = false
            });
        }
    }
}
