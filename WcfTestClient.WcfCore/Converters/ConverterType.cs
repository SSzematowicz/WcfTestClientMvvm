using System;
using System.Linq;

namespace WcfTestClient.WcfCore
{
    public static class ConverterType
    {
        public static object ConvertValueType(TypeWithName parameter)
        {
            if (parameter.BaseType == typeof(Single))
            {
                return Single.Parse((string)parameter.Value);
            }
            if (parameter.BaseType == typeof(Int32))
            {
                return int.Parse((string)parameter.Value);
            }
            if (parameter.BaseType == typeof(Boolean))
            {
                return bool.Parse((string)parameter.Value);
            }
            if (parameter.BaseType == typeof(Byte))
            {
                return Byte.Parse((string)parameter.Value);
            }
            if (parameter.BaseType == typeof(SByte))
            {
                return SByte.Parse((string)parameter.Value);
            }
            if (parameter.BaseType == typeof(Char))
            {
                return Char.Parse((string)parameter.Value);
            }
            if (parameter.BaseType == typeof(DateTime))
            {
                return DateTime.Parse((string)parameter.Value);
            }
            if (parameter.BaseType == typeof(Decimal))
            {
                return Decimal.Parse((string)parameter.Value);
            }
            if (parameter.BaseType == typeof(Int16))
            {
                return Int16.Parse((string)parameter.Value);
            }
            if (parameter.BaseType == typeof(Int32))
            {
                return Int32.Parse((string)parameter.Value);
            }
            if (parameter.BaseType == typeof(Int64))
            {
                return Int64.Parse((string)parameter.Value);
            }
            if (parameter.BaseType == typeof(Double))
            {
                return Double.Parse((string)parameter.Value);
            }
            if (parameter.BaseType == typeof(UInt16))
            {
                return UInt16.Parse((string)parameter.Value);
            }
            if (parameter.BaseType == typeof(UInt32))
            {
                return UInt32.Parse((string)parameter.Value);
            }
            if (parameter.BaseType == typeof(string))
            {
                return parameter.Value;
            }
            else
                return null;
        }

        public static object ConvertType(TypeWithName parameter)
        {
            var ob = Activator.CreateInstance(parameter.BaseType);
            var propertys = ob.GetType().GetProperties();
            foreach (var property in propertys)
            {


                var valuetype = (TypeWithName)(from pa in parameter.Properties
                                         where ((TypeWithName)pa).Name == property.Name
                                         select pa).First();
                if(valuetype.IsValueTypeOrString)
                {
                    property.SetValue(ob, Convert.ChangeType(((TypeWithName)valuetype).Value, property.PropertyType), null);
                }
                else if(valuetype.Name != "ExtensionData")
                {
                    property.SetValue(ob, ConvertType(valuetype));
                }
            }
            return ob;
        }
    }
}
