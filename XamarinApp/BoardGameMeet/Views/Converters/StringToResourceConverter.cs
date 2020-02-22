using System;
using System.Globalization;
using Xamarin.Forms;

namespace BoardGameMeet.Views.Converters
{
    public class StringToResourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string name)
            {
                return ImageSource.FromResource($"BoardGameMeet.Resources.{name}.png");     
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
