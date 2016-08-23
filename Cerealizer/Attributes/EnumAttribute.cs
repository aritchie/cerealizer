using System;
using System.Reflection;


namespace Cerealizer.Attributes
{
    public class EnumAttribute : CerealPropertyAttribute
    {
        public EnumAttribute(int startIndex) : base(startIndex, 1)
        {
        }


        public override object Parse(PropertyInfo property, byte[] data)
        {
            var enumValue = Enum.ToObject(property.PropertyType, data[this.StartIndex]);
            return enumValue;
        }
    }
}
