using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using TaxiMobile.Models;
using Xamarin.Forms;

namespace TaxiMobile.Converters
{
    public class MenuIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type = (MenuItemType)value;

            switch (type)
            {
                case MenuItemType.Home:
                    return "home.png";
                case MenuItemType.Search:
                    return "search.png";
                case MenuItemType.Login:
                    return "login.png";
                case MenuItemType.Map:
                    return "map.png";
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
