using System;
using System.Collections.Generic;
using Framework;

namespace Domain
{
    public sealed class PinSnapshot : ValueObject
    {
        public PinId PinId { get; }
        public PinStatus PinStatus { get; }
        public DateTime Timestamp { get; }

        public PinSnapshot(
            PinId pinId,
            PinStatus pinStatus,
            DateTime timestamp)
        {
            PinId = pinId;
            PinStatus = pinStatus;
            Timestamp = timestamp;
        }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return PinId;
            yield return PinStatus;
            yield return Timestamp;
        }

        public override string ToString()
        {
            return $"{nameof(PinId)}: {PinId}, {nameof(PinStatus)}: {PinStatus}, {nameof(Timestamp)}: {Timestamp}";
        }
    }
}