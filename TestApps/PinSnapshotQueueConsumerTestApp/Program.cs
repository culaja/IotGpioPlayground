using System;
using System.Threading;
using LiteQueueAdapter;

namespace PinSnapshotQueueConsumerTestApp
{
    class Program
    {
        static void Main()
        {
            using (var liteQueueBuilder = LiteQueueBuilder.NewBuilderUsing(@"..\..\..\..\TestQueueDatabase.db"))
            {
                var pinSnapshotQueue = liteQueueBuilder.PinSnapshotQueueOf("TestQueue");

                while (true)
                {
                    if (!pinSnapshotQueue.DequeueWithAction(Console.WriteLine))
                    {
                        Console.WriteLine("No items in queue ...");
                        Thread.Sleep(1000);
                    }
                }
            }
        }
    }
}