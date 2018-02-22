using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfTestClient.ViewModel;

namespace WcfTestClientMvvm
{
    public class ViewModelLocator : ViewModelBase
    {
        public static ViewModelLocator Instance => new ViewModelLocator();

        public ApplicationViewModel ApplicationViewModel => IoCConteiner.Get<ApplicationViewModel>(); 
    }
}
