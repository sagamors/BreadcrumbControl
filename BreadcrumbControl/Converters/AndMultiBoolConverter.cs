using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace BreadcrumbControl.Converters
{
    [ValueConversion(typeof(object), typeof(bool))]
    public class AndMultiBoolConverter : IMultiValueConverter
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
            return values.Length > 0 && values.All(value => (bool)System.Convert.ChangeType(value, typeof(bool)));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new Exception("Cant convert back");
        }
    }

}
