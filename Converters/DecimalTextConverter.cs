using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace TaxiMobile.Converters
{
    public class DecimalTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString();
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


