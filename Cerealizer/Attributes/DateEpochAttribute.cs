using System;
using System.Reflection;


namespace Cerealizer.Attributes
{
    public class DateEpochAttribute : CerealPropertyAttribute
    {
        static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);


        public DateEpochAttribute(int startIndex) : base(startIndex, 4)
        {
        }


        public override object Deserialize(PropertyInfo property, byte[] data)
        {
            var seconds = Math.Abs(BitConverter.ToUInt32(data, this.StartIndex));
            var value = UnixEpoch.AddSeconds(seconds);
            return value;
        }
    }
}
