using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PropertyChanged;

namespace WcfTestClient.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (s, e) => { };

        public void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        #region Command Helpers
        protected async Task RunCommand(Expression<Func<bool>> updatingFlag, Func<Task> action)
        {
            if (updatingFlag.GetPropertyValue())
            {
                return;
            }

            updatingFlag.SetPropertyValue(true);
            
            try
            {
                await action();
            }
            finally
            {
                updatingFlag.SetPropertyValue(false);
            }
        }
        #endregion
    }
}
