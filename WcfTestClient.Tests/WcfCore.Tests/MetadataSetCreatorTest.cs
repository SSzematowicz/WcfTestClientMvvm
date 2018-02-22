using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfTestClient.WcfCore;

namespace WcfTestClient.Tests.WcfCore.Tests
{
    [TestFixture]
    class MetadataSetCreatorTest
    {
        string hostAddress = @"http:\\localhost:8080";

        [Test]
        public void MetadataSetCreator_IsInstanceOfIMetadataSetCreator()
        {
            var metadataSetCreator = new MetadataSetCreator(hostAddress);

            Assert.IsInstanceOf(typeof(IMetadataSetCreator), metadataSetCreator);
        }
    }
}
