using System;
using System.Reflection;


namespace Cerealizer.Attributes
{
    public class CoordinateAttribute : CerealPropertyAttribute
    {
        public const double MILLIARCSECONDS_TO_DEGREES = 3600000;


        public CoordinateAttribute(int startIndex) : base(startIndex, 4)
        {
        }


        public override object Deserialize(PropertyInfo property, byte[] data)
        {
            return BitConverter.ToInt32(data, this.StartIndex) / MILLIARCSECONDS_TO_DEGREES;
        }
    }
}
