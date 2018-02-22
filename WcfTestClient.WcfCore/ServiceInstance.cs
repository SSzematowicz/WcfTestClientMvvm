using System.Collections.Generic;

namespace WcfTestClient.WcfCore
{
    /// <summary>
    /// Class reprezent single Service
    /// </summary>
    public class ServiceInstance
    {
        /// <summary>
        /// Name of the ServiceContract
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// List of the operations in the service contract
        /// </summary>
        public List<Operation> ServiceOprations { get; set; }

        /// <summary>
        /// Instance of this Service
        /// </summary>
        public object Instance { get; set; }
    }
}
