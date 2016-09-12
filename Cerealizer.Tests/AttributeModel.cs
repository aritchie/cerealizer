using System;
using Cerealizer.Attributes;


namespace Cerealizer.Tests
{
    public class AttributeModel
    {
        [DateEpoch(12)] // 12-15
        public DateTime TimestampUtc { get; set; }

        [Enum(11)]
        public State Status { get; set; }

        [Coordinate(0)]
        public double Value1 { get; set; }

        [Coordinate(4)]
        public double Value2 { get; set; }
    }


    public enum State
    {
        Yay = 0,
        Hi = 1,
        Bye = 2
    }
}