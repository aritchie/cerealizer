using System;
using System.Globalization;
using System.Linq;


namespace Cerealizer
{
    public static class Extensions
    {
        public static byte[] FromHex(this string hex)
        {
            hex = hex
                .Replace("-", String.Empty)
                .Replace(" ", String.Empty);

            if (hex.Length % 2 != 0)
                throw new ArgumentException("Invalid hex string");

            var bytes = new byte[hex.Length / 2];
            for (var i = 0; i < bytes.Length; i++)
            {
                var value = hex.Substring(i * 2, 2);
                bytes[i] = Byte.Parse(value, NumberStyles.HexNumber);
            }
            return bytes;
        }


        public static string ToHex(this byte[] bytes)
        {
            return String.Concat(bytes.Select(b => b.ToString("X2")));
        }
    }
}
