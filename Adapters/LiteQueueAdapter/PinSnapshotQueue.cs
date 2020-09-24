using System;
using Domain;
using Framework;
using LiteQueue;
using Ports;

namespace LiteQueueAdapter
{
    internal sealed class PinSnapshotQueue : IPinSnapshotQueue
    {
        private readonly LiteQueue<PinSnapshotDto> _liteQueue;

        public PinSnapshotQueue(LiteQueue<PinSnapshotDto> liteQueue)
        {
            _liteQueue = liteQueue;
        }
        
        public void Enqueue(PinSnapshot pinSnapshot) => _liteQueue.Enqueue(PinSnapshotDto.From(pinSnapshot));

        public bool DequeueWithAction(Action<PinSnapshot> action)
        {
            var optionalQueueEntry = _liteQueue.Dequeue().ToOptional();
            if (optionalQueueEntry.HasValue)
            {
                try
                {
                    action(optionalQueueEntry.Value.Payload.ToDomain());
                    _liteQueue.Commit(optionalQueueEntry.Value);
                }
                catch
                {
                    _liteQueue.Abort(optionalQueueEntry.Value);
                    throw;
                }
            }

            return optionalQueueEntry.HasValue;
        }
    }
}