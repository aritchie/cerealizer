using System;
using System.Linq;
using Cerealizer.Attributes;
using FluentAssertions;
using NUnit.Framework;


namespace Cerealizer.Tests
{
    [TestFixture]
    public class AttributeBufferParserTests
    {
        [TestCase("91-5c-68-09-d0-66-f8-ee-94-01-00-00-82-8f-fa-56-0f-02-00-00")]
        public void Deserialize_Success_Test(string hex)
        {
            var bytes = hex.FromHex();
            var serializer = new AttributeCerealizer();
            var obj = serializer.Deserialize<AttributeModel>(bytes);

            obj.TimestampUtc.Should().Be(new DateTime(2016, 3, 29, 14, 21, 54, DateTimeKind.Utc));
            obj.Status.Should().Be(State.Yay);
            obj.Value1.Should().Be(43.84288472222222);
            obj.Value2.Should().Be(-79.36406666666667);
        }


        [TestCase("91-5c-68-09-d0-66-f8-ee-94-01-00-00-82-8f-fa-56-0f-02-00-00")]
        public void Serializer_Success(string hex)
        {
            var bytes = hex.FromHex();
            var serializer = new AttributeCerealizer();
            var obj = serializer.Deserialize<AttributeModel>(bytes);
            var bytes2 = serializer.Serialize(obj); // TODO: if I don't serialize all original bytes, this will fail obviously
            var hex2 = BitConverter.ToString(bytes2);

            hex.Should().BeEquivalentTo(hex2);
        }
    }
}
