using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace ResourcesClient.Controls.Support
{
    public class CheckBoxValueConverter : IValueConverter
    {
        #region IValueConverter Members

        // VIKRAM CHANGES: Changes to the converter to support ThreeState checkbox with null also as a possible value
        // Value of null indicates that boolean filter is NOT SET
        // If String is empty, then return null from converter.
        // Checkbox filter is bound to FilterCurrentData.QueryString
        // which has values True/False/""
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool result = false;

            if (value == null)
            {
                return null;
            }
            if (value != null && value.GetType() == typeof(String))
            {
                if (value.ToString().Length == 0)
                {
                    return null;
                }
                else
                {
                    Boolean.TryParse(value.ToString(), out result);
                }
            }
            else if (value != null)
            {
                result = System.Convert.ToBoolean(value);
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }

        #endregion
    }
}
