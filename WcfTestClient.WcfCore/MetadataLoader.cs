using System.ServiceModel.Description;

namespace WcfTestClient.WcfCore
{
    public class MetadataLoader : IMetadataLoader
    {
        #region Fields

        MetadataSet mMetadataSet;

        #endregion //Fields

        public MetadataLoader(IMetadataSetCreator MetadataSetCreator)
        {
            mMetadataSet = MetadataSetCreator.CreateMetadataExchangeClient();
        }

        #region Public Methods

        public MetadataInfo GetMetadata()
        {
            MetadataImporter importer = new WsdlImporter(mMetadataSet);

            return new MetadataInfo()
            {
                Contracts = importer.ImportAllContracts(),
                Endpoints = importer.ImportAllEndpoints(),
                Bindings = ((WsdlImporter)importer).ImportAllBindings()
            };
        }

        #endregion //Public Methods
    }
}
