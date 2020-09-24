using System;
using System.Threading;
using Domain;
using SimulatorAdapter;
using static Framework.ListCreator;

namespace InputPinChangeSourceTestApp
{
    public sealed class Program
    {
        public static void Main()
        {
            var cancellationTokenSource = new CancellationTokenSource();
            
            var thread = new Thread(() =>
            {
                var inputPinChangeSourceSimulator = new InputPinChangeSourceSimulator(
                    ListOf(PinId.Of(1), PinId.Of(2)),
                    cancellationTokenSource.Token);

                foreach (var pinSnapshot in inputPinChangeSourceSimulator.StreamOfContinuousChanges)
                {
                    Console.WriteLine(pinSnapshot);
                }
            });
            
            thread.Start();

            Console.ReadLine();
            cancellationTokenSource.Cancel();

            thread.Join();
        }
    }
}