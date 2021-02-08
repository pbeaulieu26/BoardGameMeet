using System;
using System.Globalization;
using Xamarin.Forms;

namespace BoardGameMeet.Views.Converters
{
    public class ErrorToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool error)
            {
                if (error)
                {
                    return Color.Red;
                }
                else
                {
                    return Color.LightGreen;
                }
            }

            throw new ArgumentException("Value is not of type bool");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
