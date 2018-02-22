using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using WcfTestClient.WcfCore;

namespace WcfTestClient.ViewModel
{
    public class ServicesViewModel : ViewModelBase
    {
        public IList<ServiceViewModel> Services { get; set; }

        public ServicesViewModel(List<ServiceInstance> metadata = null)
        {
            Services = new List<ServiceViewModel>();

            if (metadata == null)
            {
                return;
            }

            foreach (var item in metadata)
            {
                ServiceViewModel service = new ServiceViewModel();
                service.ServiceNamw = item.ServiceName;
                foreach (var i in item.ServiceOprations)
                {
                    service.Operations.Add(new OperationViewModel
                    {
                        OperationName = i.Name,
                        Parameters = i.Parameters,
                        ReturnType = i.ReturnType,
                        Instance = item.Instance
                    });
                }
                Services.Add(service);
            }
        }
    }
}
