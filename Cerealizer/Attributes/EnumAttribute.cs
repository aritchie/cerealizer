﻿using System;
using System.Reflection;


namespace Cerealizer.Attributes
{
    public class EnumAttribute : CerealAttribute
    {
        public EnumAttribute(int startIndex) : base(startIndex)
        {
        }


        public override byte[] Serialize(object value)
        {
            var raw = (int) value;
            return base.Serialize(raw);
        }


        public override object Deserialize(PropertyInfo property, byte[] data)
        {
            var enumValue = Enum.ToObject(property.PropertyType, data[this.StartIndex]);
            return enumValue;
        }
    }
}
