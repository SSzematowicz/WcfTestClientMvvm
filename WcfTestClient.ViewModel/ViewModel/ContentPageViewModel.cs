using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;
using WcfTestClient.WcfCore;

namespace WcfTestClient.ViewModel
{
    public class ContentPageViewModel : ViewModelBase
    {
        public string Name { get; set; }

        public ObservableCollection<Parameter> Parameters { get; set; }

        public TypeBase ReturnType { get; set; }

        public object Instance { get; set; }

        public ICommand InvokeOperationCommand { get; set; }

        public ContentPageViewModel()
        {
            InvokeOperationCommand = new RaleyCommand(Invoke);
        }

        private void Invoke(object obj)
        {
            var methodInfo = Instance.GetType().GetMethod(Name);
            var parameterInfo = methodInfo.GetParameters();
            var arguments = new object[parameterInfo.Length];
            for(var i = 0; i < parameterInfo.Length; i++)
            {
                if(Parameters[i].IsValueTypeOrString)
                {
                    arguments[i] = ConverterType.ConvertValueType(Parameters[i]);
                }
                else
                {
                    arguments[i] = ConverterType.ConvertType(Parameters[i]);
                }

            }

            var result = methodInfo.Invoke(Instance,
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public, 
                null, arguments, CultureInfo.CurrentCulture);
            //ToDoo : Create Reurn type and show it 
        }
    }
}
