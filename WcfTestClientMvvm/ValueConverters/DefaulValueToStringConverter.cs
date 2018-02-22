using System;
using System.Globalization;
using System.Windows;

namespace WcfTestClientMvvm
{
    public class DefaulValueToStringConverter : ValueConverterBase<DefaulValueToStringConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return "null";
            return value.ToString();
        }


        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
