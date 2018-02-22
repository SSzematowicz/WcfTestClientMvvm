using System.ServiceModel.Description;

namespace WcfTestClient.WcfCore
{
    public interface IMetadataSetCreator
    {
        MetadataSet CreateMetadataExchangeClient();
    }
}