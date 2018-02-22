using System;
using System.Collections.Generic;
using System.Globalization;
using WcfTestClient.ViewModel;
using WcfTestClient.WcfCore;

namespace WcfTestClientMvvm
{
    public class MetadataInfoToServicesViewModelConverter : ValueConverterBase<MetadataInfoToServicesViewModelConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture) => new ServicesViewModel((List<ServiceInstance>)value);
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
