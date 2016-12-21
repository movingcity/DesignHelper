using System.Windows.Data;
using System;
using System.Globalization;
using System.Windows;

namespace ResourcesClient.Controls
{
    /// <summary>
    /// Negate the standard BoolToVisibilityConverter.
    /// </summary>
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class NegateBoolToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Negate the standard BoolToVisibilityConverter
        /// Returns Visibility.Collapsed when value passed is true.
        /// Returns Visibility.Visible when value passed is false.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool && targetType == typeof(Visibility))
            {
                return (bool)value ? Visibility.Collapsed : Visibility.Visible;
            }
            // default
            return Visibility.Collapsed;
        }

        /// <summary>
        /// Not supported
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }
}
