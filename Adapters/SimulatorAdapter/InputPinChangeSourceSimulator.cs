using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Domain;
using Ports;
using static System.DateTime;
using static Domain.PinStatus;

namespace SimulatorAdapter
{
    public class InputPinChangeSourceSimulator : IInputPinChangeSource
    {
        private readonly CancellationToken _cancellationToken;
        private readonly Dictionary<PinId, PinStatus> _pinStatusCache;

        public InputPinChangeSourceSimulator(
            IReadOnlyList<PinId> pinIds,
            CancellationToken cancellationToken)
        {
            _cancellationToken = cancellationToken;
            _pinStatusCache = pinIds.ToDictionary(pinId => pinId, _ => PinStatusLow);
        }

        public IEnumerable<PinSnapshot> StreamOfContinuousChanges
        {
            get
            {
                var pinIds = _pinStatusCache.Keys.ToList();
                while (!_cancellationToken.IsCancellationRequested)
                {
                    foreach (var pinId in pinIds)
                    {
                        yield return SimulateSinglePinSnapshot(pinId);
                    }
                    Thread.Sleep(1000);
                }
            }
        }

        private PinSnapshot SimulateSinglePinSnapshot(PinId pinId)
        {
            var newPinStatus = _pinStatusCache[pinId] == PinStatusHigh ? PinStatusLow : PinStatusHigh;
            _pinStatusCache[pinId] = newPinStatus;
            return new PinSnapshot(pinId, newPinStatus, UtcNow);
        }
    }
}