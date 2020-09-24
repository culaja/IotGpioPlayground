using System;
using System.Threading;
using Domain;
using LiteQueueAdapter;
using static System.DateTime;

namespace PinSnapshotQueueTestApp
{
    public sealed class Program
    {
        public static void Main()
        {
            using (var liteQueueBuilder = LiteQueueBuilder.NewBuilderUsing("TestQueueDatabase.db"))
            {
                var pinSnapshotQueue = liteQueueBuilder.PinSnapshotQueueOf("TestQueue");

                while (true)
                {
                    var pinSnapshot = new PinSnapshot(PinId.Of(1), PinStatus.PinStatusHigh, UtcNow);
                    pinSnapshotQueue.Enqueue(pinSnapshot);
                    Console.WriteLine($"Enqueued: {pinSnapshot}");
                    Thread.Sleep(1000);
                }
            }
        }
    }
}