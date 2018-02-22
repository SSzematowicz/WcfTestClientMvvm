using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfTestClient.ViewModel
{
    public class OperationDesigneViewModel : OperationViewModel
    {
        public static OperationDesigneViewModel Instance => new OperationDesigneViewModel();

        #region Consturctor
        public OperationDesigneViewModel()
        {
            OperationName = "AddMethod";
        }
        #endregion
    }
}
