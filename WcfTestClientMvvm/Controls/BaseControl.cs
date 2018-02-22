using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WcfTestClient.ViewModel;

namespace WcfTestClientMvvm
{
    public class BaseControl : UserControl
    {
        private object mViewModel;
        
        public object ViewModel
        {
            get { return mViewModel; }
            set
            {
                if (mViewModel == value)
                {
                    return;
                }

                mViewModel = value;
                OnViewModelChanged();
                this.DataContext = mViewModel;
            }
        }

        protected virtual void OnViewModelChanged() { }
    }

    public class BaseControl<VM> : BaseControl
        where VM : ViewModelBase, new()
    {
        #region Public Property

        public VM ViewModelProperty
        {
            get => (VM)ViewModel;
            set => ViewModel = value;
        }

        #endregion

        #region Constructors
        public BaseControl(VM specificViewModel = null) : base()
        {
            if (specificViewModel != null)
            {
                ViewModelProperty = specificViewModel;
            }
            else
            {
                ViewModelProperty = IoCConteiner.Get<VM>();
            }
        }

        public BaseControl() : base()
        {
           ViewModelProperty = IoCConteiner.Get<VM>();
        }
        #endregion
    }

}
