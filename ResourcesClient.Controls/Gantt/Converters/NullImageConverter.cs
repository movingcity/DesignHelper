using System.Windows.Data;
using System;
using System.Globalization;
using System.Windows;

namespace ResourcesClient.Controls.Converters
{
    /// <summary>
    /// Converter that checks for a null value and unsets the property value.
    /// Prevents a null exception from binding of null values to ImageSource.
    /// </summary>
    public class NullImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return DependencyProperty.UnsetValue;
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
