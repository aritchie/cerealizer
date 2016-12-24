using System;
using System.Linq;
using System.Reactive.Linq;
using Acr.Ble;


namespace Cerealizer.BleExtensions
{
    public static class BleExtensions
    {

        public static IObservable<T> SubscribeToCharacteristic<T>(this ICerealizer cerealizer, IDevice device, Guid characteristicId, int waitMillis = 2000)
        {
            return Observable.Create<T>(async ob =>
            {
                var characteristics = await device.GetAllCharacteristics(waitMillis);
                var ch = characteristics.FirstOrDefault(x => x.Uuid.Equals(characteristicId));
                if (ch == null)
                    throw new ArgumentException($"Characteristic '{characteristicId}' not found");

                return cerealizer
                    .SubscribeToCharacteristic<T>(ch)
                    .Subscribe(ob.OnNext);
            });
        }


        public static IObservable<T> SubscribeToCharacteristic<T>(this ICerealizer cerealizer, IGattCharacteristic characteristic)
        {
            if (!characteristic.CanNotify())
                throw new ArgumentException("Characteristic does not support notification");

            return characteristic
                .SubscribeToNotifications()
                .Select(x => cerealizer.Deserialize<T>(x.Data));
        }


        public static IObservable<T> ReadMessage<T>(this ICerealizer cerealizer, IDevice device, Guid characteristicId, int waitMillis = 2000)
        {
            return Observable.Create<T>(async ob =>
            {
                var characteristics = await device.GetAllCharacteristics(waitMillis);
                var ch = characteristics.FirstOrDefault(x => x.Uuid.Equals(characteristicId));
                if (ch == null)
                    throw new ArgumentException($"Characteristic '{characteristicId}' not found");

                return cerealizer
                    .ReadMessage<T>(ch)
                    .Subscribe(ob.OnNext);
            });
        }


        public static IObservable<T> ReadMessage<T>(this ICerealizer cerealizer, IGattCharacteristic characteristic)
        {
            if (!characteristic.CanRead())
                throw new ArgumentException("Characteristic does not support notification");

            return characteristic
                .Read()
                .Select(x => cerealizer.Deserialize<T>(x.Data));
        }


        public static IObservable<T> ReadMessageInterval<T>(this ICerealizer cerealizer, IGattCharacteristic characteristic, TimeSpan interval)
        {
            if (!characteristic.CanRead())
                throw new ArgumentException("Characteristic does not support notification");

            return characteristic
                .ReadInterval(interval)
                .Select(x => cerealizer.Deserialize<T>(x.Data));
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
