using System;
using System.Reactive.Linq;
using Acr.Ble;


namespace Cerealizer.BleExtensions
{
    public static class BleExtensions
    {

        public static IObservable<T> WhenNotificationMessage<T>(this IGattCharacteristic characteristic, ICerealizer cerealizer)
        {
            if (!characteristic.CanNotify())
                throw new ArgumentException("Characteristic does not support notification");

            return characteristic
                .WhenNotificationOccurs()
                .Select(cerealizer.Deserialize<T>);
        }


        public static IObservable<T> WhenReadMessage<T>(this IGattCharacteristic characteristic, ICerealizer cerealizer)
        {
            if (!characteristic.CanRead())
                throw new ArgumentException("Characteristic does not support notification");

            return characteristic
                .Read()
                .Select(cerealizer.Deserialize<T>);
        }


        public static IObservable<T> WhenReadIntervalMessage<T>(this IGattCharacteristic characteristic, ICerealizer cerealizer, TimeSpan interval)
        {
            if (!characteristic.CanRead())
                throw new ArgumentException("Characteristic does not support notification");

            return characteristic
                .ReadInterval(interval)
                .Select(cerealizer.Deserialize<T>);
        }


        public static IObservable<object> WriteCereal<T>(this IGattCharacteristic characteristic, ICerealizer cerealizer, T value)
        {
            if (!characteristic.CanRead())
                throw new ArgumentException("Characteristic does not support notification");

            var data = cerealizer.Serialize(value);
            return characteristic.Write(data);
        }
    }
}
