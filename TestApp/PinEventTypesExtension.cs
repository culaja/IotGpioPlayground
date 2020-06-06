using System;
using System.Device.Gpio;

namespace TestApp
{
    public static class PinEventTypesExtension
    {
        public static PinValue ToPinValue(this PinEventTypes pinEventTypes)
        {
            switch (pinEventTypes)
            {
                case PinEventTypes.Rising: return PinValue.High;
                case PinEventTypes.Falling: return PinValue.Low;
                default: throw new ArgumentOutOfRangeException(nameof(pinEventTypes), pinEventTypes, null);
            }
        }
    }
}