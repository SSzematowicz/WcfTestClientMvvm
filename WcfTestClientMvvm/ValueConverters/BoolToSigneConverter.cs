using System;
using System.Globalization;
using System.Windows;

namespace WcfTestClientMvvm
{
    public class BoolToSigneConverter : ValueConverterBase<BoolToSigneConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? Application.Current.FindResource("FontAwesomeMinusIcon") : Application.Current.FindResource("FontAwesomePlusIcon");
        }


        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
