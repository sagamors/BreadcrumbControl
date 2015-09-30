using System;
using System.Globalization;
using System.Windows.Data;

namespace BreadcrumbControl.Converters
{
    [ValueConversion(typeof(object), typeof(bool))]
    public class OrMultiBoolConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            foreach (var value in values)
            {
                if (value.GetType() != typeof(bool))
                {
                    return null;
                }
            }
            foreach (var value in values)
            {
                if ((bool)value == true)
                {
                    return true;
                }
            }
            return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("Cant convert back");
        }
    }
}
