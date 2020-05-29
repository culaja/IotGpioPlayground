using System;
using System.Device.Gpio;

namespace TestApp
{
    class Program
    {
        private const int InputPin = 1;
        private const int OutputPin = 2;
        
        private static readonly GpioController Controller = new GpioController();

        static void Main()
        {
            Controller.OpenPin(InputPin, PinMode.Input);
            Controller.OpenPin(OutputPin, PinMode.Output);
            Controller.RegisterCallbackForPinValueChangedEvent(InputPin, PinEventTypes.None, Callback);
            
            Console.ReadLine();
            
            Controller.UnregisterCallbackForPinValueChangedEvent(InputPin, Callback);
            Controller.ClosePin(OutputPin);
            Controller.ClosePin(InputPin);
            Controller.Dispose();
        }

        private static void Callback(object sender, PinValueChangedEventArgs args)
        {
            Console.WriteLine($"Received '{args.ChangeType}' signal on pin '{args.PinNumber}'");
            Controller.Write(OutputPin, args.ChangeType.ToPinValue());
        }
    }
}