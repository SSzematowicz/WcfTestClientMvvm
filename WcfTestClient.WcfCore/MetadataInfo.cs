using System.ServiceModel.Description;
using System.ServiceModel.Channels;
using System.Collections.ObjectModel;
using System.CodeDom.Compiler;

namespace WcfTestClient.WcfCore
{
    public class MetadataInfo
    {
        #region Fields
        Collection<ContractDescription> mContracts;
        Collection<ServiceEndpoint> mEndpoints;
        Collection<Binding> mBinddings;
        #endregion //Fields

        #region public Property
        public Collection<ContractDescription> Contracts
        {
            get => mContracts ?? (mContracts = new Collection<ContractDescription>());
            set => mContracts = value;
        }

        public Collection<ServiceEndpoint> Endpoints
        {
            get => mEndpoints ?? (mEndpoints = new Collection<ServiceEndpoint>());
            set => mEndpoints = value;
        }

        public Collection<Binding> Bindings
        {
            get => mBinddings ?? (mBinddings = new Collection<Binding>());
            set => mBinddings = value;
        }

        public CodeDomProvider CodeDomProvider { get; private set; }

        public CodeGeneratorOptions GeneratorOptions { get; protected set; }
        #endregion // public Property

        #region Constructor
        public MetadataInfo()
        {

        }

        #endregion //Constructor
    }
}
