using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace TaxiMobile.Converters
{
    public class DecimalDistanceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((decimal)value / 1000).ToString() + " km";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return (decimal)value;
            }
            catch
            {
                value = (value as string).Substring(0, (value as string).Length - 1);
                return 0;
            }
        }
    }
}
