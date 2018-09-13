using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using TaxiMobile.Contracts.Services;
using TaxiMobile.Models;
using TaxiMobile.Utility;
using Xamarin.Forms;

namespace TaxiMobile.Converters
{
    public class MenuTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type = (MenuItemType)value;
            switch (type)
            {
                case MenuItemType.Home:
                    return "Home";
                case MenuItemType.Search:
                    return "Search driver";
                case MenuItemType.Login:
                    if (AppContainer.Resolve<IDriverDataService>().ActiveDriver == null)
                        return "Log in";
                    else
                        return "Log out";
                case MenuItemType.Map:
                    return "Show yourself";
                default:
                    return string.Empty;
            }
           

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Not needed here
            throw new NotImplementedException();
        }
    }
}
