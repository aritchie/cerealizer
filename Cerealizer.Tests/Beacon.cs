using System;
using Cerealizer.Attributes;


namespace Cerealizer.Tests
{
    public class Beacon
    {
        [Guid(4)]
        public Guid Uuid { get; set; }

        [Cereal(20, IsLittleEndian = false)]
        public ushort Major { get; set; }

        [Cereal(22, IsLittleEndian = false)]
        public ushort Minor { get; set; }

        //[Cereal(29)]
        //public byte TxPower { get; set; }
    }
}