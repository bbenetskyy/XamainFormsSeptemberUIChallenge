using System;
using System.Globalization;
using Xamarin.Forms;

namespace SeptemberUIChallenge.Converters
{
    public class StringToTagsConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is string tags)
            {
                return tags.Split(',');
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}