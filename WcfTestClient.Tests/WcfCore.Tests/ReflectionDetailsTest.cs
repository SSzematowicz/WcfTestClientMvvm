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
    class ReflectionDetailsTest
    {
        [Test]
        public void ReflectionDetails_GoodName_CreateOperation()
        {
            string operationName = "ExtraMethod";
            MyTestClass myTestClass = new MyTestClass();

            var operation = ReflectionDetails.GenerateOperation(myTestClass, operationName);
            var result = operation.Name;

            StringAssert.Contains(operationName, operation.Name);
            Assert.NotNull(operation);
            Assert.True(operation.Parameters[0].IsValueTypeOrString);
            Assert.False(operation.Parameters[1].IsValueTypeOrString);

        }

        [Test]
        public void ReflectionDetails_BadName_ThrowException()
        {
            string operationName = "Method";
            MyTestClass myTestClass = new MyTestClass();

            var ex = Assert.Throws<ArgumentNullException>(() => ReflectionDetails.GenerateOperation(myTestClass, operationName));
            StringAssert.Contains("Bad operation name!", ex.Message);
        }

    }

    public class MyTestClass
    {
        public void ExtraMethod(int argOne, MyExtraClass argTwo)
        { }
    }

    public class MyExtraClass
    { }
}
