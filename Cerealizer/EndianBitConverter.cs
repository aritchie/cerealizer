using System;
using System.Linq;


namespace Cerealizer
{
    public static class EndianBitConverter
    {
        public static byte[] GetBytes(bool value, bool littleEndian = true)
        {
            return littleEndian
                ? BitConverter.GetBytes(value)
                : BitConverter.GetBytes(value).Reverse().ToArray();
        }


        public static byte[] GetBytes(char value, bool littleEndian = true)
        {
            return littleEndian
                ? BitConverter.GetBytes(value)
                : BitConverter.GetBytes(value).Reverse().ToArray();
        }


        public static byte[] GetBytes(double value, bool littleEndian = true)
        {
            return littleEndian
                ? BitConverter.GetBytes(value)
                : BitConverter.GetBytes(value).Reverse().ToArray();
        }


        public static byte[] GetBytes(float value, bool littleEndian = true)
        {
            return littleEndian
                ? BitConverter.GetBytes(value)
                : BitConverter.GetBytes(value).Reverse().ToArray();
        }


        public static byte[] GetBytes(int value, bool littleEndian = true)
        {
            return littleEndian
                ? BitConverter.GetBytes(value)
                : BitConverter.GetBytes(value).Reverse().ToArray();
        }


        public static byte[] GetBytes(long value, bool littleEndian = true)
        {
            return littleEndian
                ? BitConverter.GetBytes(value)
                : BitConverter.GetBytes(value).Reverse().ToArray();
        }


        public static byte[] GetBytes(short value, bool littleEndian = true)
        {
            return littleEndian
                ? BitConverter.GetBytes(value)
                : BitConverter.GetBytes(value).Reverse().ToArray();
        }


        public static byte[] GetBytes(uint value, bool littleEndian = true)
        {
            return littleEndian
                ? BitConverter.GetBytes(value)
                : BitConverter.GetBytes(value).Reverse().ToArray();
        }


        public static byte[] GetBytes(ulong value, bool littleEndian = true)
        {
            return littleEndian
                ? BitConverter.GetBytes(value)
                : BitConverter.GetBytes(value).Reverse().ToArray();
        }


        public static byte[] GetBytes(ushort value, bool littleEndian = true)
        {
            return littleEndian
                ? BitConverter.GetBytes(value)
                : BitConverter.GetBytes(value).Reverse().ToArray();
        }


        public static short ToInt16(byte[] value, int startIndex, bool littleEndian = true)
        {
            return littleEndian
                ? BitConverter.ToInt16(value, startIndex)
                : BitConverter.ToInt16(value.Reverse().ToArray(), value.Length - sizeof(short) - startIndex);
        }


        public static int ToInt32(byte[] value, int startIndex, bool littleEndian = true)
        {
            return littleEndian
                ? BitConverter.ToInt32(value, startIndex)
                : BitConverter.ToInt32(value.Reverse().ToArray(), value.Length - sizeof(int) - startIndex);
        }


        public static long ToInt64(byte[] value, int startIndex, bool littleEndian = true)
        {
            return littleEndian
                ? BitConverter.ToInt64(value, startIndex)
                : BitConverter.ToInt64(value.Reverse().ToArray(), value.Length - sizeof(long) - startIndex);
        }


        public static float ToSingle(byte[] value, int startIndex, bool littleEndian = true)
        {
            return littleEndian
                ? BitConverter.ToSingle(value, startIndex)
                : BitConverter.ToSingle(value.Reverse().ToArray(), value.Length - sizeof(float) - startIndex);
        }


        public static double ToDouble(byte[] value, int startIndex, bool littleEndian = true)
        {
            return littleEndian
                ? BitConverter.ToDouble(value, startIndex)
                : BitConverter.ToDouble(value.Reverse().ToArray(), value.Length - sizeof(double) - startIndex);
        }


        public static string ToString(byte[] value, bool littleEndian = true)
        {
            return littleEndian
                ? BitConverter.ToString(value)
                : BitConverter.ToString(value.Reverse().ToArray());
        }


        public static string ToString(byte[] value, int startIndex, bool littleEndian = true)
        {
            return littleEndian
                ? BitConverter.ToString(value, startIndex)
                : BitConverter.ToString(value.Reverse().ToArray(), startIndex);
        }


        public static string ToString(byte[] value, int startIndex, int length, bool littleEndian = true)
        {
            return littleEndian
                ? BitConverter.ToString(value, startIndex, length)
                : BitConverter.ToString(value.Reverse().ToArray(), startIndex, length);
        }


        public static ushort ToUInt16(byte[] value, int startIndex, bool littleEndian = true)
        {
            return littleEndian
                ? BitConverter.ToUInt16(value, startIndex)
                : BitConverter.ToUInt16(value.Reverse().ToArray(), value.Length - sizeof(ushort) - startIndex);
        }


        public static uint ToUInt32(byte[] value, int startIndex, bool littleEndian = true)
        {
            return littleEndian
                ? BitConverter.ToUInt32(value, startIndex)
                : BitConverter.ToUInt32(value.Reverse().ToArray(), value.Length - sizeof(uint) - startIndex);
        }


        public static ulong ToUInt64(byte[] value, int startIndex, bool littleEndian = true)
        {
            return littleEndian
                ? BitConverter.ToUInt64(value, startIndex)
                : BitConverter.ToUInt64(value.Reverse().ToArray(), value.Length - sizeof(ulong) - startIndex);
        }
    }
}