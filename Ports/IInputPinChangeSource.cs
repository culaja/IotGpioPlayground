using System.Collections.Generic;
using Domain;

namespace Ports
{
    public interface IInputPinChangeSource
    {
        IEnumerable<PinSnapshot> StreamOfContinuousChanges { get; }
    }
}