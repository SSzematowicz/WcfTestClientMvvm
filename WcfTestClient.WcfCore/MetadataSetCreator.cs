using System;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;
using System.ServiceModel;

namespace WcfTestClient.WcfCore
{
    /// <summary>
    /// Class creates the Metadataset object based on data from user 
    /// </summary>
    public class MetadataSetCreator : IMetadataSetCreator
    {
        #region Fields

        const byte ReceivedMessageSizMultiplier = 5;
        string mAddress;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="MexAddress">Endpoint addresss from user</param>
        public MetadataSetCreator(string MexAddress)
        {
            if(string.IsNullOrWhiteSpace(MexAddress))
            {
                throw new ArgumentNullException("MexAddress");
            }

            mAddress = MexAddress;
        }

        #endregion

        #region Public Helpers
        /// <summary>
        /// Create MetadataSet
        /// </summary>
        /// <returns></returns>
        public MetadataSet CreateMetadataExchangeClient()
        {
            MetadataExchangeClient client = null;
            if (TryCreateMetadataExchangeClientForHttpGet(out client))
            {
                var httpGetAddress = CreateHttpGetAddress(mAddress);
                client.ResolveMetadataReferences = true;
                var set = client.GetMetadata(new Uri(httpGetAddress),
                    MetadataExchangeClientMode.HttpGet);
                return set;
            }
            if (TryCreateMetadataExchangeClientForMex(out client))
            {
                var mexAddress = CreateMexAddress(mAddress);
                client.ResolveMetadataReferences = true;
                var set = client.GetMetadata(new EndpointAddress(mexAddress));
                return set;
            }
            else
            {
                throw new Exception("MetadataExchangeClient");
            }
        }

        #endregion

        #region Private Helpers

        /// <summary>
        /// Try to create MetadataExchangeClient for GttpGet exchange mode
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        private bool TryCreateMetadataExchangeClientForHttpGet(out MetadataExchangeClient client)
        {
            var address = new Uri(mAddress);
            var GetAddress = CreateHttpGetAddress(mAddress);
            BindingElement bindingElement = null;

            if (address.Scheme == Uri.UriSchemeHttp)
            {
                var httpTransport = new HttpTransportBindingElement();
                httpTransport.MaxReceivedMessageSize *= ReceivedMessageSizMultiplier;
                bindingElement = httpTransport;
            }

            if (address.Scheme == Uri.UriSchemeHttps)
            {
                var httpsTransport = new HttpsTransportBindingElement();
                httpsTransport.MaxReceivedMessageSize *= ReceivedMessageSizMultiplier;
                bindingElement = httpsTransport;
            }


            try
            {
                var binding = new CustomBinding(bindingElement);
                client = new MetadataExchangeClient(binding);
                return true;
            }
            catch
            {
                client = null;
                return false;
            }

        }

        /// <summary>
        /// Try to create MetadataExchangeClient for Mex exchange mode
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        private bool TryCreateMetadataExchangeClientForMex(out MetadataExchangeClient client)
        {
            
            var bindingElement = CreateBindingElement(mAddress);


            try
            {
                var binding = new CustomBinding(bindingElement);
                client = new MetadataExchangeClient(binding);
                return true;
            }
            catch
            {
                client = null;
                return false;
            }




        }

        /// <summary>
        /// Create the right binding element for the endpoint address schema
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        private static BindingElement CreateBindingElement(string MexAddress)
        {
            if(string.IsNullOrWhiteSpace(MexAddress))
            {
                throw new ArgumentNullException("MexAddress");
            }

            var address = new Uri(MexAddress);

            if (address.Scheme == Uri.UriSchemeHttp)
            {
                return new HttpTransportBindingElement();
            }
            if (address.Scheme == Uri.UriSchemeHttps)
            {
                return new HttpsTransportBindingElement();
            }
            if (address.Scheme == Uri.UriSchemeNetTcp)
            {
                return new TcpTransportBindingElement();
            }
            if (address.Scheme == Uri.UriSchemeNetPipe)
            {
                return new NamedPipeTransportBindingElement();
            }
            else
            {
                throw new Exception("Can't Create binding element!");
            }
            
        }

        /// <summary>
        /// Add '?wsdl' to the endpoint address if it is not there
        /// </summary>
        /// <param name="mAddress">endpint address</param>
        /// <returns></returns>
        private string CreateHttpGetAddress(string mAddress)
        {
            if(string.IsNullOrWhiteSpace(mAddress))
            {
                throw new ArgumentException("mAddress");
            }

            if (mAddress.EndsWith("?wsdl") == false)
            {
                mAddress += "?wsdl";
            }
            return mAddress;
        }


        /// <summary>
        /// Add '/mex' to the endpoint address if it is not there
        /// </summary>
        /// <param name="mAddress">endpint address</param>
        /// <returns></returns>
        private string CreateMexAddress(string mAddress)
        {
            if (string.IsNullOrWhiteSpace(mAddress))
            {
                throw new ArgumentException("mAddress");
            }

            if (mAddress.EndsWith("/mex") == false)
            {
                mAddress += "/mex";
            }
            return mAddress;
        }

        #endregion //Private Helpers
    }
}
