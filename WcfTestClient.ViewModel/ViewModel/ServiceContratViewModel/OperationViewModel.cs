using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WcfTestClient.WcfCore;

namespace WcfTestClient.ViewModel
{
    public class OperationViewModel : ViewModelBase
    {
        public string OperationName { get; set; }

        public ObservableCollection<Parameter> Parameters { get; set; }

        public BasicType ReturnType { get; set; }

        public object Instance { get; set; }

        #region Commands

        public ICommand OpenOperationCommand { get; private set; }

        #endregion

        #region Constructor
        public OperationViewModel()
        {
            OpenOperationCommand = new RaleyCommand(parm =>
                {
                    IoCConteiner.Get<ApplicationViewModel>().ContentPageViewModel = new ContentPageViewModel
                    {
                        Parameters = Parameters,
                        ReturnType = ReturnType,
                        Name = OperationName,
                        Instance = Instance
                    };
                }
            );
        }
        #endregion
    }
}
