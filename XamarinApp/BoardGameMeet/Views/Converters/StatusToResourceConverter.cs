using BoardGameMeet.Models;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace BoardGameMeet.Views.Converters
{
    public class StatusToResourceConverter : IValueConverter
    {
        private const string ResourceBlueInterrogationMark = "blue_interrogation_mark.png";
        private const string ResourceGreenCheckMark = "green_check_mark.png";
        private const string ResourceRedCross = "red_cross.png";
        private const string ResourceRedExclamationMark = "red_exclamation_mark.png";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Availability availibility)
            {
                return ImageSource.FromResource($"BoardGameMeet.Resources.{AvailabilityToResource(availibility)}");
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private string AvailabilityToResource(Availability availibility)
        {
            switch (availibility)
            {
                case Availability.Unspecified: return ResourceBlueInterrogationMark;
                case Availability.Present: return ResourceGreenCheckMark;
                case Availability.Absent: return ResourceRedCross;
                case Availability.Cancelled: return ResourceRedExclamationMark;
                default: return string.Empty;
            }
        }
    }
}
