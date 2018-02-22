using System;
using System.Windows.Input;

namespace WcfTestClient.ViewModel
{
     public class RaleyCommand : ICommand
    {
        #region Fields

        Action<object> mExecute;
        Predicate<object> mCanExecute;

        #endregion //Fields

        #region Constructor
        /// <summary>
        /// Create a new command that can always execute
        /// </summary>
        /// <param name="Execute">the execute logic</param>
        public RaleyCommand(Action<object> Execute)
            : this(Execute, null)
        {

        }

        /// <summary>
        /// Create a new command.
        /// </summary>
        /// <param name="Execute">the execute logic.</param>
        /// <param name="CanExecute">the execute status logic</param>
        public RaleyCommand(Action<object> Execute, Predicate<object> CanExecute)
        {
            if (Execute == null)
            {
                throw new ArgumentException("Execute");
            }

            mExecute = Execute;
            mCanExecute = CanExecute;
        }

        #endregion //Constructor
        
        #region ICommand Memeber
        public event EventHandler CanExecuteChanged = (s, e) => { };

        public bool CanExecute(object parameter) => mCanExecute == null ? true : mCanExecute(parameter);

        public void Execute(object parameter) => mExecute(parameter);
        #endregion //ICommand Memeber
    }
}
