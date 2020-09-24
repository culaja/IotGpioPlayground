using System;
using System.Threading;
using Domain;
using LiteQueueAdapter;

namespace PinSnapshotQueueConsumerTestApp
{
    class Program
    {
        static void Main()
        {
            using (var liteQueueBuilder = LiteQueueBuilder.NewBuilderUsing("TestQueueDatabase.db"))
            {
                var pinSnapshotQueue = liteQueueBuilder.PinSnapshotQueueOf("TestQueue");

                while (true)
                {
                    var optionalPinSnapshot = pinSnapshotQueue.Dequeue();
                    if (optionalPinSnapshot.HasNoValue)
                    {
                        Console.WriteLine("No items in queue ...");
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Console.WriteLine(optionalPinSnapshot.Value);
                    }
                }
            }
        }
    }
}