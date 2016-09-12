using System;
using System.Reflection;


namespace Cerealizer.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class CerealAttribute : Attribute
    {
        public CerealAttribute(int startIndex)
        {
            this.StartIndex = startIndex;
        }


        public virtual byte[] Serialize(object value)
        {
            var type = value.GetType();
            this.AssertNonNullable(type);

            if (type == typeof(bool) || type == typeof(byte) || type == typeof(sbyte))
                return new [] { (byte)value };

            if (type == typeof(short))
                return EndianBitConverter.GetBytes((short)value, this.IsLittleEndian);

            if (type == typeof(int))
                return EndianBitConverter.GetBytes((int)value, this.IsLittleEndian);

            if (type == typeof(long))
                return EndianBitConverter.GetBytes((long)value, this.IsLittleEndian);

            if (type == typeof(ushort))
                return EndianBitConverter.GetBytes((ushort)value, this.IsLittleEndian);

            if (type == typeof(uint))
                return EndianBitConverter.GetBytes((uint)value, this.IsLittleEndian);

            if (type == typeof(ulong))
                return EndianBitConverter.GetBytes((ulong)value, this.IsLittleEndian);

            if (type == typeof(double))
                return EndianBitConverter.GetBytes((double)value, this.IsLittleEndian);

            if (type == typeof(float))
                return EndianBitConverter.GetBytes((float)value, this.IsLittleEndian);

            throw new ArgumentException($"Cannot work with this type - {type}");
        }


        public virtual object Deserialize(PropertyInfo property, byte[] data)
        {
            this.AssertNonNullable(property.PropertyType);

            if (property.PropertyType == typeof(bool))
                return data[this.StartIndex] == 1;

            if (property.PropertyType == typeof(byte))
                return data[this.StartIndex];

            if (property.PropertyType == typeof(sbyte))
                return data[this.StartIndex];

            if (property.PropertyType == typeof(short))
                return EndianBitConverter.ToInt16(data, this.StartIndex, this.IsLittleEndian);

            if (property.PropertyType == typeof(int))
                return EndianBitConverter.ToInt32(data, this.StartIndex, this.IsLittleEndian);

            if (property.PropertyType == typeof(long))
                return EndianBitConverter.ToInt64(data, this.StartIndex, this.IsLittleEndian);

            if (property.PropertyType == typeof(ushort))
                return EndianBitConverter.ToUInt16(data, this.StartIndex, this.IsLittleEndian);

            if (property.PropertyType == typeof(uint))
                return EndianBitConverter.ToUInt32(data, this.StartIndex, this.IsLittleEndian);

            if (property.PropertyType == typeof(ulong))
                return EndianBitConverter.ToInt64(data, this.StartIndex, this.IsLittleEndian);

            if (property.PropertyType == typeof(double))
                return EndianBitConverter.ToDouble(data, this.StartIndex, this.IsLittleEndian);

            if (property.PropertyType == typeof(float))
                return EndianBitConverter.ToSingle(data, this.StartIndex, this.IsLittleEndian);

            throw new ArgumentException($"Cannot work with this type - {property.PropertyType}");
        }


        public int StartIndex { get; }
        public bool IsLittleEndian { get; set; } = true;


        protected virtual void AssertNonNullable(Type type)
        {
            if (this.IsNullableType(type))
                throw new ArgumentException("Nullable types are not supported");
        }


        protected virtual bool IsNullableType(Type type)
        {
            var ti = type.GetTypeInfo();
            if (!ti.IsGenericType)
                return false;

            if (ti.GetGenericTypeDefinition() != typeof(Nullable<>))
                return false;

            return true;
        }
    }
}
