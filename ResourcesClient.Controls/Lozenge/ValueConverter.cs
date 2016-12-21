using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows;

namespace ResourcesClient.Controls
{

    [ValueConversion(typeof(LozengeEnd), typeof(Geometry))]
    class LeftPointsConverter : IValueConverter
    {
        #region IValueConverter Members

        private static readonly Geometry LeftArrow = Geometry.Parse(String.Format("M10,0 L8,0 L0,15 L8,30 L10,30"));
        private static readonly Geometry LeftSaw = Geometry.Parse(String.Format("M10,0 L8,0 L0,5 L8,10 L0,15 L8,20 L0,25 L8,30 L10,30"));
        private static readonly Geometry LeftStraight = Geometry.Parse(String.Format("M10,0 L8,0 L8,10 L10,10"));

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch ((LozengeEnd)value)
            {
                case LozengeEnd.Arrow:
                    return LeftArrow;
                case LozengeEnd.Saw:
                    return LeftSaw;
                case LozengeEnd.Straight:
                default:
                    return LeftStraight;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        #endregion
    }

    [ValueConversion(typeof(LozengeEnd), typeof(Geometry))]
    class RightPointsConverter : IValueConverter
    {
        #region IValueConverter Members

        private static readonly Geometry RightArrow = Geometry.Parse(String.Format("M0,0 L2,0 L10,15 L2,30 L0,30"));
        private static readonly Geometry RightSaw = Geometry.Parse(String.Format("M0,0 L2,0 L10,5 L2,10 L10,15 L2,20 L10,25 L2,30 L0,30"));
        private static readonly Geometry RightStraight = Geometry.Parse(String.Format("M0,0 L2,0 L2,30 L0,30"));

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch ((LozengeEnd)value)
            {
                case LozengeEnd.Arrow:
                    return RightArrow;
                case LozengeEnd.Saw:
                    return RightSaw;
                case LozengeEnd.Straight:
                default:
                    return RightStraight;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        #endregion
    }


    [ValueConversion(typeof(double), typeof(Thickness))]
    class LozengeThicknessConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double thickness = (double)value;
            return new Thickness(0.0, thickness, 0.0, thickness);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        #endregion
    }


}
