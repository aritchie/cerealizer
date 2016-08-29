using System;
using System.Diagnostics;
using Cerealizer.Attributes;
using Cerealizer.Tests;


namespace Cerealizer.PerfTests
{
    class Program
    {
        const int runs = 100000;


        static void Main(string[] args)
        {
            var packet = "4c-00-02-15-9d-d3-c2-d7-c0-5e-41-74-92-d2-cc-30-62-9e-52-27-00-01-00-0a".FromHex();
            Run("Cerealizer Tests", () => RunCerealizer(runs, packet));
            Run("Raw Tests", () => RunRaw(runs, packet));
            Console.WriteLine("Test Complete.  Press <ENTER> to quit");
            Console.ReadLine();
        }


        static void Run(string category, Action action)
        {
            Console.WriteLine("Starting " + category);
            var sw = new Stopwatch();
            sw.Start();
            action();
            sw.Stop();
            Console.WriteLine($"{category} finished in {sw.Elapsed}");
        }


        static void RunCerealizer(int count, byte[] packet)
        {
            var cerealizer = new AttributeCerealizer();
            for (var i = 0; i < count; i++)
            {
                var b = cerealizer.Deserialize<Beacon>(packet);
            }
        }


        static void RunRaw(int count, byte[] packet)
        {
            for (var i = 0; i < count; i++)
            {
                var uuid =  EndianBitConverter
                    .ToString(packet, 4, 16, true)
                    .Replace("-", String.Empty);

                var b = new Beacon
                {
                    Uuid = new Guid(uuid),
                    Major = EndianBitConverter.ToUInt16(packet, 20, false),
                    Minor = EndianBitConverter.ToUInt16(packet, 22, false)
                };
            }
        }
    }
}