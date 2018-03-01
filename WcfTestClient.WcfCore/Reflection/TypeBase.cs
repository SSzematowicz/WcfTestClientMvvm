using System.Collections.Generic;
using System;
using System.Linq;

namespace WcfTestClient.WcfCore
{
    public class TypeBase
    {
        public Type BaseType { get; set; }

        public List<object> Properties { get; set; } = new List<object>();

        public object Value { get; set; }

        public bool IsValueTypeOrString => BaseType.IsValueType || BaseType == typeof(string);

        public bool HaveProperties => Properties.Count(f => f != null) > 0;

        public object DefaulValue => GetDefaul(BaseType);

        private object GetDefaul(Type baseType)
        {
            if(baseType.IsValueType)
            {
                return Activator.CreateInstance(BaseType);
            }
            return null;
        }
    }
}
