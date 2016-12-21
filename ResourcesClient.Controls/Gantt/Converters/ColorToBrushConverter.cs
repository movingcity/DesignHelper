using System.Windows.Data;
using System.Windows.Media;
using System;

namespace ResourcesClient.Controls.Converters
{
    public class ColorToBrushConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is Color)
            {
                Color color = (Color)value;
                // change the alpha channel to add transparency
                color.A = 0x19;
                return new SolidColorBrush(color);
            }
            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
