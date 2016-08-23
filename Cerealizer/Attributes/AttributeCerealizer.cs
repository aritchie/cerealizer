using System;
using System.Collections.Generic;
using System.Reflection;


namespace Cerealizer.Attributes
{
    public class AttributeCerealizer : ICerealizer
    {
        static readonly IDictionary<Type, IList<Tuple<PropertyInfo, CerealPropertyAttribute>>> cache = new Dictionary<Type, IList<Tuple<PropertyInfo, CerealPropertyAttribute>>>();


        public byte[] Serialize(object obj)
        {
            return null;
        }


        public T Deserialize<T>(byte[] data)
        {
            var obj = Activator.CreateInstance<T>();
            var props = this.GetTypeCache(typeof(T));

            foreach (var prop in props)
            {
                var value = prop.Item2.Parse(prop.Item1, data);
                prop.Item1.SetValue(obj, value);
            }
            return obj;
        }


        IList<Tuple<PropertyInfo, CerealPropertyAttribute>> GetTypeCache(Type type)
        {
            if (cache.ContainsKey(type))
                return cache[type];

            var props = type.GetRuntimeProperties();
            var list = new List<Tuple<PropertyInfo, CerealPropertyAttribute>>();

            foreach (var prop in props)
            {
                var attr = prop.GetCustomAttribute<CerealPropertyAttribute>();
                if (attr != null)
                {
                    var tuple = new Tuple<PropertyInfo, CerealPropertyAttribute>(prop, attr);
                    list.Add(tuple);
                }
            }
            cache.Add(type, list);
            return list;
        }
    }
}