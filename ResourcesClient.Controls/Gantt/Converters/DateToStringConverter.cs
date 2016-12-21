using System;
using System.Text;
using System.Windows.Data;

namespace ResourcesClient.Controls.Converters
{
    public class DateToStringConverter : IMultiValueConverter
    {
        /// <summary>
        /// Convert passed date and date format string into formatted date string
        /// </summary>
        /// <param name="values"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values.Length > 1 && values[0] is DateTime && values[1] is string)
            {
                DateTime date = (DateTime)values[0];
                string format = values[1] as string;

                return date.ToString(format);
            }
            return Binding.DoNothing;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
