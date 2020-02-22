using System;
using System.Globalization;
using Xamarin.Forms;

namespace BoardGameMeet.Views.Converters
{
    public class CountToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int count)
            {
                if (parameter is string invert && invert == "invert")
                {
                    return count > 0 ? false : true;
                }
                return count > 0 ? true : false;
            }

            throw new ArgumentException("Value is not of type int");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
