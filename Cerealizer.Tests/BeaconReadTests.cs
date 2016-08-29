using System;
using Cerealizer.Attributes;
using FluentAssertions;
using NUnit.Framework;


namespace Cerealizer.Tests
{
    [TestFixture]
    public class BeaconReadTests
    {
        [TestCase("4c-00-02-15-9d-d3-c2-d7-c0-5e-41-74-92-d2-cc-30-62-9e-52-27-00-01-00-04-00", (ushort)1, (ushort)4)]
        [TestCase("4c-00-02-15-9d-d3-c2-d7-c0-5e-41-74-92-d2-cc-30-62-9e-52-27-00-01-00-0a", (ushort)1, (ushort)10)]
        public void Beacon(string hex, ushort major, ushort minor)
        {
            var bytes = hex.FromHex();
            var beacon = new AttributeCerealizer().Deserialize<Beacon>(bytes);
            beacon.Should().NotBeNull("Beacon not parsed");
            beacon.Uuid.Should().Be("9dd3c2d7-c05e-4174-92d2-cc30629e5227");
            beacon.Major.Should().Be(major);
            beacon.Minor.Should().Be(minor);
        }
    }
}
