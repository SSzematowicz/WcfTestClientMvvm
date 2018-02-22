using System.Windows.Controls;
using WcfTestClient.ViewModel;

namespace WcfTestClientMvvm
{
    /// <summary>
    /// Logika interakcji dla klasy HostAddressEntryControl.xaml
    /// </summary>
    public partial class HostAddressEntryControl : UserControl
    {
        public HostAddressEntryControl()
        {
            InitializeComponent();
            DataContext = new HostAddressEntryViewModel();
        }
    }
}
