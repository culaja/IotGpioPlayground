using System;
using System.Device.Gpio;

namespace TestApp
{
    public static class PinEventTypesExtension
    {
        public static PinValue ToPinValue(this PinEventTypes pinEventTypes) =>
            pinEventTypes switch
            {
                PinEventTypes.Rising => PinValue.High,
                PinEventTypes.Falling => PinValue.Low,
                _ => throw new ArgumentOutOfRangeException(nameof(pinEventTypes), pinEventTypes, null)
            };
    }
}