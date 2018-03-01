using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WcfTestClient.WcfCore
{
    /// <summary>
    /// Reprezent single ServiceOperation
    /// </summary>
    public class Operation
    {
        /// <summary>
        /// Name of the Method
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// List of the parameters 
        /// </summary>
        public ObservableCollection<Parameter> Parameters { get; set; } = new ObservableCollection<Parameter>();

        /// <summary>
        /// Return Type
        /// </summary>
        public TypeBase ReturnType { get; set; }
    }
}
