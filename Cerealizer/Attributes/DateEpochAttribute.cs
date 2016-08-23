using System;
using System.Reflection;


namespace Cerealizer.Attributes
{
    public class DateEpochAttribute : CerealPropertyAttribute
    {
        static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);


        public DateEpochAttribute(int startIndex) : base(startIndex)
        {
        }


        public override byte[] Serialize(object value)
        {
            var ticks = ((DateTime) value).Ticks - UnixEpoch.Ticks;
            return BitConverter.GetBytes(ticks);
        }


        public override object Deserialize(PropertyInfo property, byte[] data)
        {
            var raw = BitConverter.ToUInt32(data, this.StartIndex);
            var seconds = Math.Abs(raw);
            var value = UnixEpoch.AddSeconds(seconds);
            return value;
        }
    }
}
