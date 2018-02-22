using System.Windows;
using System.Windows.Controls;
using WcfTestClient.ViewModel;
using WcfTestClient.WcfCore;

namespace WcfTestClientMvvm
{
    public class ViewModelSelector : DataTemplateSelector
    {
        public DataTemplate PropertyVM { get; set; }
        public DataTemplate TypeVM { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container) => ((Member)item).IsValueTypeOrString ? PropertyVM : TypeVM;
    }
}
