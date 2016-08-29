using System;
using System.Reflection;
using System.Text;


namespace Cerealizer.Attributes
{
    public class StringAttribute : CerealAttribute
    {
        public StringAttribute(int startIndex, int length) : base(startIndex)
        {
            this.Length = length;
        }


        public override byte[] Serialize(object value)
        {
            return Encoding.UTF8.GetBytes((string) value);
        }

        public override object Deserialize(PropertyInfo property, byte[] data)
        {
            return BitConverter.ToString(data, this.StartIndex, this.Length);
        }


        public int Length { get; }
    }
}
