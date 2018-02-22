using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfTestClient.ViewModel
{
    public class ServicesDesigneViewModel : ServicesViewModel
    {
        public static ServicesDesigneViewModel Instance => new ServicesDesigneViewModel();

        public ServicesDesigneViewModel()
        {
            Services = new List<ServiceViewModel>
            {

                new ServiceViewModel
                {
                    ServiceNamw = @"IWcfServiceOne",

                    Operations = new List<OperationViewModel>()
                    {
                        new OperationViewModel{ OperationName = "AddMethod"},
                        new OperationViewModel {OperationName = "DevideMethod"}
                    }
                },

                new ServiceViewModel
                {
                    ServiceNamw = @"IWcfServiceTwo",

                    Operations = new List<OperationViewModel>()
                    {
                        new OperationViewModel{ OperationName = "MultiplyMethod"},
                        new OperationViewModel {OperationName = "SubscribeMethod"}
                    }
                },
            };
        }
    }
}
