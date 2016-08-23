using System;
using System.Reflection;


namespace Cerealizer.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class CerealPropertyAttribute : Attribute
    {
        // big or little endian
        public CerealPropertyAttribute(int startIndex, int length)
        {
            this.StartIndex = startIndex;
            this.Length = length;
        }


        public virtual byte[] Serialize(object value)
        {
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

            if (property.PropertyType == typeof(int))
                return BitConverter.ToInt32(data, this.StartIndex);

            if (property.PropertyType == typeof(ushort))
                return BitConverter.ToInt16(data, this.StartIndex);

            if (property.PropertyType == typeof(string))
                return BitConverter.ToString(data, this.StartIndex, this.Length);

            throw new ArgumentException($"Cannot parse this type - {property.PropertyType}");
        }


        //public virtual byte[] ToBuffer(PropertyInfo property, object obj)
        public int StartIndex { get; }
        public int Length { get; }
    }
}
