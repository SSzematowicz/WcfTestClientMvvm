using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WcfTestClient.ViewModel
{
    public class ServiceViewModel : ViewModelBase
    {
        public bool IsOperationListVisable { get; set; } = true;

        public ICommand ShowOperationListCommand { get; private set; }

        public string ServiceNamw { get; set; }

        public List<OperationViewModel> Operations { get; set; } = new List<OperationViewModel>();

        public ServiceViewModel()
        {           
            ShowOperationListCommand = new RaleyCommand(parm => IsOperationListVisable ^= true);
        }
    }
}
