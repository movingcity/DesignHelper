using System;
using System.Windows.Data;

namespace ResourcesClient.Controls.Converters
{
    public class WidthToLocationConverter : IMultiValueConverter
    {
        // convert the passed canvas and control width/height and return the centered location
        // first parameter in binding is total width, second is the control width
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values.Length > 1 && values[0] is double && values[1] is double)
            {
                double extra = 0;
                if (parameter != null)
                {
                    extra = System.Convert.ToDouble(parameter);
                }
                return ((double)values[0] - (double)values[1]) / 2 + extra;
            }
            return 0;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
