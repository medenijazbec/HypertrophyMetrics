using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace HypertrophyApp.Converters
{
    public class SelectedButtonBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string selectedOption = value as string;
            string buttonOption = parameter as string;

            return selectedOption == buttonOption ? Colors.White : Color.FromArgb("#c3c3c8");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
