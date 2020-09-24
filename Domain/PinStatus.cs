using System.Collections.Generic;
using Framework;

namespace Domain
{
    public sealed class PinStatus : ValueObject
    {
        public static readonly PinStatus PinStatusHigh = new PinStatus(true);
        public static readonly PinStatus PinStatusLow = new PinStatus(false);
        
        private readonly bool _value;

        private PinStatus(bool value)
        {
            _value = value;
        }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _value;
        }

        public override string ToString() => _value ? nameof(PinStatusHigh) : nameof(PinStatusLow);

        public static implicit operator bool(PinStatus pinStatus) => pinStatus._value;
    }
}