using System.Collections.Generic;
using WcfTestClient.WcfCore;

namespace WcfTestClient.ViewModel
{
    public class ApplicationViewModel : ViewModelBase
    {
        public bool HostAddressControlVisible { get; set; } = false;

        public bool ServicesListVisible { get; set; } = false;

        public List<ServiceInstance> Services { get; set; }

        public PropertysViewModel PropertysVm { get; set; } = new PropertysViewModel();

        public ContentPageViewModel ContentPageViewModel { get; set; } = new ContentPageViewModel();
    }
}
