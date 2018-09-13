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
    public class MenuVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type = (MenuItemType)value;
            switch (type)
            {
                case MenuItemType.Home:
                    return true; ;
                case MenuItemType.Search:
                    return true;
                case MenuItemType.Login:
                    return true;
                case MenuItemType.Map:
                    if (AppContainer.Resolve<IDriverDataService>().ActiveDriver == null)
                        return false;
                    else
                        return true;
                default:
                    return true;
            }


        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Not needed here
            throw new NotImplementedException();
        }
    }
}
