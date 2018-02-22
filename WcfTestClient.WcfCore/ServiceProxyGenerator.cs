using System.ServiceModel.Description;
using System.CodeDom.Compiler;
using System;
using System.Reflection;
using System.Linq;
using System.ServiceModel;
using System.Globalization;
using System.Collections.Generic;

namespace WcfTestClient.WcfCore
{
    public class ServiceProxyGenerator
    {
        #region Fields

        IMetadataLoader mMetadataLoader;

        #endregion

        #region Constructors

        public ServiceProxyGenerator(IMetadataLoader metadataLoader)
        {
            mMetadataLoader = metadataLoader;
        }

        #endregion

        public List<ServiceInstance> CreateGenerator()
        {
            var serviceInstances = new List<ServiceInstance>();

            var metadataInfo = mMetadataLoader.GetMetadata();

            var serviceContractGenerator = new ServiceContractGenerator
            {
                Options = ServiceContractGenerationOptions.ClientClass
            };

            foreach (var contract in metadataInfo.Contracts)
            {
                serviceContractGenerator.GenerateServiceContractType(contract);
            }

            if (serviceContractGenerator.Errors.Count != 0)
            {
                throw new Exception("ServiceContractGenerator: " + serviceContractGenerator.Errors.ToString());
            }

            var codeDom = CodeDomProvider.CreateProvider("C#");
            var generatorOptions = new CodeGeneratorOptions
            {
                BracingStyle = "C"
            };

            var codeDomProvider = CodeDomProvider.CreateProvider("C#");
            var compilerParameters = new CompilerParameters(
                new string[]
                {
                    "System.dll",
                    "System.ServiceModel.dll",
                    "System.Runtime.Serialization.dll"
                }
            );

            var results = codeDomProvider.CompileAssemblyFromDom(compilerParameters,
                serviceContractGenerator.TargetCompileUnit);

            var contractAssembly = Assembly.LoadFile(results.PathToAssembly);
            var list = new List<object>();

            foreach (var contract in metadataInfo.Contracts)
            {

                var endpoint = GetEndpoint(metadataInfo, contract);
                var serviceInterface = GetServiceInterface(contractAssembly, contract);
                var serviceInstance = new ServiceInstance
                {
                    ServiceName = serviceInterface.Name,
                    ServiceOprations = new List<Operation>()
                };

                var proxyInstance = CreateProxyInstance(contractAssembly, serviceInterface);

                var inst = results.CompiledAssembly.CreateInstance(proxyInstance.Name, false,
                    BindingFlags.CreateInstance, null,
                    new object[] { endpoint.Binding, endpoint.Address },
                    CultureInfo.CurrentCulture, null);

                serviceInstance.Instance = inst;
                //Generate operation
                foreach (var operationName in contract.Operations.Select(x => x.Name).ToArray())
                {
                    serviceInstance.ServiceOprations.Add(ReflectionDetails.GenerateOperation(inst, operationName));
                }
                serviceInstances.Add(serviceInstance);
            }
            return serviceInstances;
        }

        #region Private Helpers
        private static Type CreateProxyInstance(Assembly contractAssembly, Type serviceInterface)
        {
            return (from t in contractAssembly.GetTypes()
                    where t.IsClass &&
                    t.GetInterface(serviceInterface.Name) != null &&
                    t.GetInterface(typeof(ICommunicationObject).Name) != null
                    select t).First();
        }

        private static Type GetServiceInterface(Assembly contractAssembly, ContractDescription contract)
        {
            return (from t in contractAssembly.GetTypes()
                    where t.IsInterface &&
                    t.GetCustomAttributes(false).Any(a => a is ServiceContractAttribute)
                    && t.Name == contract.Name
                    select t).First();
        }

        private static ServiceEndpoint GetEndpoint(MetadataInfo metadataInfo, ContractDescription contract)
        {
            return (from i in metadataInfo.Endpoints
                    where i.Contract.Name == contract.Name && i.Contract.Namespace == contract.Namespace
                    select i).First();
        }
        #endregion // Private Helpers
    }
}
