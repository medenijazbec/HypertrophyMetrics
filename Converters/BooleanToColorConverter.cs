using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace HypertrophyApp.Converters
{
    public class BooleanToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isTrue = (bool)value;
            string parameterString = parameter as string;

            if (parameterString == "GrayToRed")
            {
                return isTrue ? Colors.Red : Colors.Gray;
            }

            return Colors.Gray;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
