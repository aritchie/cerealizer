using System;


namespace Cerealizer
{
    public interface ICerealizer
    {
        byte[] Serialize(object obj);
        T Deserialize<T>(byte[] data);
        //int GetPacketLengthForType<T>();
    }
}
