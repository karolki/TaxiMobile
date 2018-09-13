using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TaxiMobile.Models
{
    public class MainMenuItem : BindableObject
    {
        private string _menuText;
        public string MenuText
        {
            get
            {
                return _menuText;
            }
            set
            {
                _menuText = value;
                OnPropertyChanged();
            }
        }
        private Type _viewModelToLoad;
        public Type ViewModelToLoad
        {
            get
            {
                return _viewModelToLoad;
            }
            set
            {
                _viewModelToLoad = value;
                OnPropertyChanged();
            }
        }
        private MenuItemType _menuItemType;
        public MenuItemType MenuItemType
        {
            get
            {
                return _menuItemType;
            }
            set
            {
                _menuItemType = value;
                OnPropertyChanged();
            }
        }
        private bool _isVisible;
        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                _isVisible = value;
                OnPropertyChanged();
            }
        }
    }
    public enum MenuItemType
    {
        Home,
        Search,
        Map,
        Login
    }
}
