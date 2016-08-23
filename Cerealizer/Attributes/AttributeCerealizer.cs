using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace Cerealizer.Attributes
{
    public class AttributeCerealizer : ICerealizer
    {
        static readonly IDictionary<Type, IList<Tuple<PropertyInfo, CerealPropertyAttribute>>> cache = new Dictionary<Type, IList<Tuple<PropertyInfo, CerealPropertyAttribute>>>();


        public byte[] Serialize(object obj)
        {
            var byteLists = new List<byte[]>();
            var props = this.GetTypeCache(obj.GetType());

            foreach (var prop in props)
            {
                var value = prop.Item1.GetValue(obj);
                var data = prop.Item2.Serialize(value);
                byteLists.Add(data);
            }
            return this.Combine(byteLists.ToArray());
        }


        public T Deserialize<T>(byte[] data)
        {
            var obj = Activator.CreateInstance<T>();
            var props = this.GetTypeCache(typeof(T));

            foreach (var prop in props)
            {
                var value = prop.Item2.Deserialize(prop.Item1, data);
                prop.Item1.SetValue(obj, value);
            }
            return obj;
        }


        protected virtual byte[] Combine(params byte[][] arrays)
        {
            var rv = new byte[arrays.Sum(a => a.Length)];
            var offset = 0;

            foreach (byte[] array in arrays)
            {
                Buffer.BlockCopy(array, 0, rv, offset, array.Length);
                offset += array.Length;
            }
            return rv;
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