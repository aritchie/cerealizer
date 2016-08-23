using System;
using System.Reflection;


namespace Cerealizer.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class CerealPropertyAttribute : Attribute
    {
        public CerealPropertyAttribute(int startIndex)
        {
            this.StartIndex = startIndex;
        }


        public virtual byte[] Serialize(object value)
        {
            // TODO: nullables
            var type = value.GetType();
            if (type == typeof(bool) || type == typeof(byte))
                return BitConverter.GetBytes((byte)value);

            if (type == typeof(short))
                return BitConverter.GetBytes((short)value);

            if (type == typeof(int))
                return BitConverter.GetBytes((int)value);

            if (type == typeof(long))
                return BitConverter.GetBytes((long)value);

            if (type == typeof(ushort))
                return BitConverter.GetBytes((ushort)value);

            if (type == typeof(uint))
                return BitConverter.GetBytes((uint)value);

            if (type == typeof(ulong))
                return BitConverter.GetBytes((ulong)value);

            throw new ArgumentException($"Cannot work with this type - {type}");


            return null;
        }


        public virtual object Deserialize(PropertyInfo property, byte[] data)
        {
                //var part = data
                //    .Skip(prop.Item2.StartIndex)
                //    .Take(prop.Item2.Length)
                //    .ToArray();
            // TODO: nullable type conversion
            if (property.PropertyType == typeof(bool))
                return data[this.StartIndex] == 1;

            if (property.PropertyType == typeof(byte))
                return data[this.StartIndex];

            if (property.PropertyType == typeof(short))
                return BitConverter.ToInt16(data, this.StartIndex);

            if (property.PropertyType == typeof(int))
                return BitConverter.ToInt32(data, this.StartIndex);

            if (property.PropertyType == typeof(long))
                return BitConverter.ToInt64(data, this.StartIndex);

            if (property.PropertyType == typeof(ushort))
                return BitConverter.ToUInt16(data, this.StartIndex);

            if (property.PropertyType == typeof(uint))
                return BitConverter.ToUInt32(data, this.StartIndex);

            if (property.PropertyType == typeof(ulong))
                return BitConverter.ToInt64(data, this.StartIndex);

            throw new ArgumentException($"Cannot work with this type - {property.PropertyType}");
        }


        public int StartIndex { get; }
        //public bool IsBigEndian { get; set; }
    }
}
