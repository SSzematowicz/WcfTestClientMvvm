using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfTestClient.ViewModel
{
    public class ServiceDesigneViewModel : ServiceViewModel
    {
        public static ServiceDesigneViewModel Instance => new ServiceDesigneViewModel();

        public ServiceDesigneViewModel()
        {
            ServiceNamw = @"IWcfService";

            Operations = new List<OperationViewModel>()
            {
                new OperationViewModel{ OperationName = "AddMethod"},
                new OperationViewModel {OperationName = "DevideMethod"}
            };
        }
    }
}
