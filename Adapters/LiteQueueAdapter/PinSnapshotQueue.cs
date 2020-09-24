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

        public Optional<PinSnapshot> Dequeue()
        {
            var queueEntry = _liteQueue.Dequeue(); 
            return queueEntry.IsCheckedOut
                ? Optional<PinSnapshot>.None
                : queueEntry.Payload.ToDomain();
        }
    }
}