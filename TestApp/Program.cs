using System;
using System.Device.Gpio;
using System.Threading;

namespace TestApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("LED blinking started ...");
            
            var controller = new GpioController();
            
            const int greenLed = 17;
            controller.OpenPin(greenLed, PinMode.Output);

            while (true)
            {
                controller.Write(greenLed, PinValue.High);
                Console.WriteLine($"Green LED is '{PinValue.High}'");
                Thread.Sleep(1000);
                controller.Write(greenLed, PinValue.Low);
                Console.WriteLine($"Green LED is '{PinValue.Low}'");
                Thread.Sleep(1000);
            }
        }
    }

    internal sealed class Debouncer
    {
        public delegate void OnDebouncedChange(bool value);

        private bool _cashedValue;
        private bool _lastSentValue;

        public event OnDebouncedChange OnDebouncedChangeEvent;

        private readonly Timer _timer;

        public Debouncer()
        {
            _timer = new Timer(callback, null, 20, -1);
        }

        private void callback(object state)
        {
            if (_lastSentValue != _cashedValue)
            {
                OnDebouncedChangeEvent?.Invoke(_cashedValue);
                _lastSentValue = _cashedValue;
            }
        }

        public void RegisterNewInput(bool value)
        {
            _cashedValue = value;
            _timer.Change(20, -1);
        }
    }
}