using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace WcfTestClient.ViewModel
{
    public class  ParameterViewModel : ViewModelBase
    {
        /// <summary>
        /// the type of this item
        /// </summary>
        public Type PropertyType { get; set; }

        /// <summary>
        /// the name of this item
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// the value of this item
        /// </summary>
        public object Value { get; set; }


        public bool IsValueTypeOrString { get; set; }

        /// <summary>
        /// the list of oll children of this item
        /// </summary>
        public ObservableCollection<ParameterViewModel> Children { get; set; }

        public bool CanExpanded => IsValueTypeOrString == false && Children.Count(f => f != null) > 0;

        /// <summary>
        /// Indicates if the current item is expanded or not
        /// </summary>
        public bool IsExpanded => Children.Count(f => f != null) > 0;

    }
}
