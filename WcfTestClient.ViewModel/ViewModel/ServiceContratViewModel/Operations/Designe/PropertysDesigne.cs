using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WcfTestClient.WcfCore;

namespace WcfTestClient.ViewModel
{
    public class PropertysDesigne : PropertysViewModel
    {
        public static PropertysDesigne Instance => new PropertysDesigne();

        public PropertysDesigne()
        {
            PropertiesList = new ObservableCollection<Parameter>
            {
                new Parameter
                {
                     BaseType = typeof(string),
                     Name = "First Name",
                },
                new Parameter
                {
                     BaseType = typeof(string),
                     Name = "Last Name",
                },              
            };
        }
    }
}
