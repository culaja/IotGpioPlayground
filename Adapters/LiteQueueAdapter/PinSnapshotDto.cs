using System;
using Domain;

namespace LiteQueueAdapter
{
    internal sealed class PinSnapshotDto
    {
        public int PinIdentifier { get; set; }
        public bool PinStatus { get; set; }
        public DateTime Timestamp { get; set; }

        public static PinSnapshotDto From(PinSnapshot pinSnapshot) => new PinSnapshotDto
        {
            PinIdentifier = pinSnapshot.PinId,
            PinStatus = pinSnapshot.PinStatus,
            Timestamp = pinSnapshot.Timestamp
        };
        
        public PinSnapshot ToDomain() => new PinSnapshot(
            PinId.Of(PinIdentifier),
            PinStatus ? Domain.PinStatus.PinStatusHigh :  Domain.PinStatus.PinStatusLow,
            Timestamp);
    }
}