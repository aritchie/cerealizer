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
        [Test]
        public void Deserialize_Success_Test()
        {
            var bytes = StringToByteArray("91-5c-68-09-d0-66-f8-ee-94-01-00-00-82-8f-fa-56-0f-02-00-00");
            var serializer = new AttributeCerealizer();
            var obj = serializer.Deserialize<AttributeModel>(bytes);

            obj.TimestampUtc.Should().Be(new DateTime(2016, 3, 29, 14, 21, 54, DateTimeKind.Utc));
            obj.Status.Should().Be(State.Yay);
            obj.Value1.Should().Be(43.84288472222222);
            obj.Value2.Should().Be(-79.36406666666667);
        }


        [Test]
        public void Serializer_Success()
        {
            var hex = "91-5c-68-09-d0-66-f8-ee-94-01-00-00-82-8f-fa-56-0f-02-00-00";
            var bytes = StringToByteArray(hex);

            var serializer = new AttributeCerealizer();
            var obj = serializer.Deserialize<AttributeModel>(bytes);
            var bytes2 = serializer.Serialize(obj); // TODO: if I don't serialize all original bytes, this will fail obviously
            var hex2 = BitConverter.ToString(bytes2);

            hex.Should().BeEquivalentTo(hex2);
        }


        static byte[] StringToByteArray(string hex)
        {
            hex = hex
                .Replace("-", String.Empty)
                .Replace(" ", String.Empty);

            return Enumerable
                .Range(0, hex.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                .ToArray();
        }
    }
}
