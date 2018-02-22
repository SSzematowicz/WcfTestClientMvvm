using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfTestClient.WcfCore;

namespace WcfTestClient.ViewModel
{
    public class ParameterDesigneViewModel : Parameter
    {
        public static ParameterDesigneViewModel Instance => new ParameterDesigneViewModel();

        public ParameterDesigneViewModel()
        {
            BaseType = typeof(string);
            Name = "first Name";
        }
    }
}
