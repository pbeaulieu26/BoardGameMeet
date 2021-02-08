using BoardGameMeet.Helpers;
using BoardGameMeet.Models;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace BoardGameMeet.Views.Converters
{
    public class DateToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime date)
            {
                if (parameter is string param)
                {
                    if (param == "month")
                    {
                        return DateTimeFormatHelper.GetFormatedMonthOfYear(date);
                    }
                }
                else
                {
                    return DateTimeFormatHelper.GetFormatedDate(date);
                }
            }
            else if (value is EventTime eventTime)
            {
                return DateTimeFormatHelper.GetFormatedTimeSpan(eventTime);
            }

            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
