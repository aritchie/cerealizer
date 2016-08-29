using System;
using System.Reflection;


namespace Cerealizer.Attributes
{
    public class GuidAttribute : CerealAttribute
    {
        public GuidAttribute(int startIndex) : base(startIndex)
        {
        }


        public override byte[] Serialize(object value)
        {
            return ((Guid)value).ToByteArray();
        }


        public override object Deserialize(PropertyInfo property, byte[] data)
        {
            //var layout = data
            //    .Skip(this.StartIndex)
            //    .Take(16);

            //if (!this.IsLittleEndian)
            //    layout = layout.Reverse();

            //var bytes = layout.ToArray();
            //var guid = new Guid(bytes);
            var @string = EndianBitConverter
                .ToString(data, this.StartIndex, 16, this.IsLittleEndian)
                .Replace("-", String.Empty);
            var guid = new Guid(@string);
            return guid;
        }
    }
}
