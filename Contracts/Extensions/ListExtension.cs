using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TaxiMobile.Contracts.Extensions
{
    public static class ListExtension
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> list)
        {
            return new ObservableCollection<T>(list);
        }
    }
}
