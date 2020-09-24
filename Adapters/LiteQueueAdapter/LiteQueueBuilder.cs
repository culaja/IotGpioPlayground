using System;
using Domain;
using LiteDB;
using LiteQueue;
using Ports;

namespace LiteQueueAdapter
{
    public sealed class LiteQueueBuilder : IDisposable
    {
        private readonly LiteDatabase _liteDatabase;

        private LiteQueueBuilder(LiteDatabase liteDatabase)
        {
            _liteDatabase = liteDatabase;
        }

        public static LiteQueueBuilder NewBuilderUsing(string queueFilePath)
        {
            return new LiteQueueBuilder(new LiteDatabase(queueFilePath));
        }
        
        public IPinSnapshotQueue PinSnapshotQueueOf(string queueName) => 
            new PinSnapshotQueue(new LiteQueue<PinSnapshotDto>(_liteDatabase, queueName));
        
        public void Dispose()
        {
            _liteDatabase?.Dispose();
        }
    }
}