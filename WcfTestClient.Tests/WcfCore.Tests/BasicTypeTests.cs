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
    class BasicTypeTests
    {
        [TestCase(typeof(int), true)]
        [TestCase(typeof(string), true)]
        [TestCase(typeof(NotValueType), false)]
        public void IsValueTypeOrString_CheckVeriusType(Type type, bool expected)
        {
            var basicType = new BasicType { BaseType = type };

            var result = basicType.IsValueTypeOrString;

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void HaveProperties_TypeWithProperties_ReturnTrue()
        {
            var basicType = new BasicType
            {
                BaseType = typeof(NotValueType),
                Properties = new List<object> { "red", "green", 24 }
            };

            var result = basicType.HaveProperties;

            Assert.True(result);
        }

        [Test]
        public void HaveProperties_TypeWithNullProperties_ReturnFalse()
        {
            var basicType = new BasicType
            {
                BaseType = typeof(NotValueType),
                Properties = new List<object> { null, null, null }
            };

            var result = basicType.HaveProperties;

            Assert.False(result);
        }

        [Test]
        public void HaveProperties_TypeWithoutProperties_ReturnFalse()
        {
            var basicType = new BasicType
            {
                BaseType = typeof(NotValueType)
            };

            var result = basicType.HaveProperties;

            Assert.False(result);
        }


        [TestCase(typeof(int), default(int))]
        [TestCase(typeof(string), default(string))]
        [TestCase(typeof(NotValueType), default(NotValueType))]
        public void DefaulValue_VeriusType_RetunDefaulValue(Type basetype, object defaulValue)
        {
            BasicType basic = new BasicType { BaseType = basetype };

            object result = basic.DefaulValue;

            Assert.AreEqual(result, defaulValue );
        }



    }

    public class NotValueType
    {
        public int PropertyOne { get; set; }
    }
}
