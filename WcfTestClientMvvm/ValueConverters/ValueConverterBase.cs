using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace WcfTestClientMvvm
{
    public abstract class ValueConverterBase<T> : MarkupExtension, IValueConverter
        where T: class, new()
    {
        private static T mConverter = null;

        #region IValueConverter Members

        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

        #endregion //IValueConverter Members

        public override object ProvideValue(IServiceProvider serviceProvider) => mConverter ?? (mConverter = new T());
    }
}
