using System.Collections.Generic;
using Framework;

namespace Domain
{
    public sealed class PinId : ValueObject
    {
        private readonly int _number;

        private PinId(int number)
        {
            _number = number;
        }
        
        public static PinId Of(int number) => new PinId(number);
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _number;
        }

        public override string ToString() => _number.ToString();

        public static implicit operator int(PinId pinId) => pinId._number;
    }
}