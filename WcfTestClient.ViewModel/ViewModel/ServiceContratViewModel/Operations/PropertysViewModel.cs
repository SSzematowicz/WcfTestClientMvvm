using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WcfTestClient.WcfCore;

namespace WcfTestClient.ViewModel
{
    public class PropertysViewModel : ViewModelBase
    {
        public ObservableCollection<Parameter> PropertiesList { get; set; }

    }
}
