using System;
using Domain;

namespace Ports
{
    public interface IPinSnapshotQueue
    {
        void Enqueue(PinSnapshot pinSnapshot);

        bool DequeueWithAction(Action<PinSnapshot> action);
    }
}