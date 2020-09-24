using Domain;
using Framework;

namespace Ports
{
    public interface IPinSnapshotQueue
    {
        void Enqueue(PinSnapshot pinSnapshot);

        Optional<PinSnapshot> Dequeue();
    }
}