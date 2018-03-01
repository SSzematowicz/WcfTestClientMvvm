using System;
using System.Collections.Generic;

namespace WcfTestClient.WcfCore
{
    public static class ReflectionDetails
    {
        public static Operation GenerateOperation(object instance, string operationName)
        {
            var methodInfo = instance.GetType().GetMethod(operationName);

            if(methodInfo == null)
            {
                throw new ArgumentNullException("Bad operation name!");
            }

            Operation operation = new Operation { Name = operationName };
            //Get Parameters of the operation
            foreach (var parameter in methodInfo.GetParameters())
            {
                var parameterType = parameter.ParameterType;
                Parameter par = new Parameter { Name = parameter.Name, BaseType = parameterType };
                if (!parameterType.IsValueType && parameterType != typeof(string))
                {
                    par.Properties.AddRange(GetPropertys(parameterType));
                }
                operation.Parameters.Add(par);
            }
            //Get and create Return type of the operation
            var returnType = methodInfo.ReturnType;
            TypeBase ReturnType = new TypeBase { BaseType = returnType };
            if (!returnType.IsValueType && returnType != typeof(string))
            {
                ReturnType.Properties.AddRange(GetPropertys(returnType));
            }
            operation.ReturnType = ReturnType;

            return operation;
        }

        private static IEnumerable<object> GetPropertys(Type PropertyType)
        {
            List<Property> propertys = new List<Property>();
            foreach (var propertyFromType in PropertyType.GetProperties())
            {
                var propertyType = propertyFromType.PropertyType;
                Property property = new Property { Name = propertyFromType.Name, BaseType = propertyType };
                if (!propertyType.IsValueType && propertyType != typeof(string))
                {
                    property.Properties.AddRange(GetPropertys(propertyType));
                }
                propertys.Add(property);
            }
            return propertys.ToArray();
        }
    }
}
