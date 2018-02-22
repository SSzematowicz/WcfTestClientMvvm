using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WcfTestClient.ViewModel;

namespace WcfTestClientMvvm
{
    public class WindowViewModel : ViewModelBase
    {
        #region Private Fileds

        Window mWindow;

        #endregion

        #region Public Property

        public int ResizeBorder => mWindow.WindowState == WindowState.Maximized ? 0 : 4;

        public int CaptionHeight { get; set; } = 42;

        public Thickness ResizeBorderThickness => new Thickness(ResizeBorder);

        //Command
        public ICommand CloseCommand { get; private set; }
        public ICommand MinimizeCommand { get; private set; }
        public ICommand MaximizeCommand { get; private set; }

        #endregion

        #region Constructors
        public WindowViewModel(Window window)
        {
            mWindow = window;

            mWindow.StateChanged += (sender, e) =>
            {
                OnPropertyChanged("ResizeBorder");
                OnPropertyChanged("CaptionHeight");
                OnPropertyChanged("ResizeBorderThickness");
            };

            //Commad Iniciation
            CloseCommand = new RaleyCommand(parm => mWindow.Close());
            MaximizeCommand = new RaleyCommand(parm => mWindow.WindowState ^= WindowState.Maximized);
            MinimizeCommand = new RaleyCommand(parm => mWindow.WindowState = WindowState.Minimized);
        }
        #endregion
    }
}
