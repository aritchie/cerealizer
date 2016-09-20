using System;
using System.Reactive.Linq;
using Acr.Ble;


namespace Cerealizer.BleExtensions
{
    public static class BleExtensions
    {

        public static IObservable<T> SubscribeToCharacteristic<T>(this ICerealizer cerealizer, IGattCharacteristic characteristic)
        {
            if (!characteristic.CanNotify())
                throw new ArgumentException("Characteristic does not support notification");

            return characteristic
                .SubscribeToNotifications()
                .Select(cerealizer.Deserialize<T>);
        }


        public static IObservable<T> ReadMessage<T>(this ICerealizer cerealizer, IGattCharacteristic characteristic)
        {
            if (!characteristic.CanRead())
                throw new ArgumentException("Characteristic does not support notification");

            return characteristic
                .Read()
                .Select(cerealizer.Deserialize<T>);
        }


        public static IObservable<T> ReadMessageInterval<T>(this ICerealizer cerealizer, IGattCharacteristic characteristic, TimeSpan interval)
        {
            if (!characteristic.CanRead())
                throw new ArgumentException("Characteristic does not support notification");

            return characteristic
                .ReadInterval(interval)
                .Select(cerealizer.Deserialize<T>);
        }


        public static IObservable<object> WriteMessage<T>(this ICerealizer cerealizer, IGattCharacteristic characteristic, T value)
        {
            if (!characteristic.CanRead())
                throw new ArgumentException("Characteristic does not support notification");

            var data = cerealizer.Serialize(value);
            return characteristic.Write(data);
        }
    }
}
