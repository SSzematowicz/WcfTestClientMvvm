using System;
using System.Globalization;
using System.Windows;

namespace WcfTestClientMvvm
{
    public class BoolToVisibilityConverter : ValueConverterBase<BoolToVisibilityConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(parameter is null)
            {
                return (bool)value ? Visibility.Visible : Visibility.Collapsed;
            }
            else
            {
                return (bool)value ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
