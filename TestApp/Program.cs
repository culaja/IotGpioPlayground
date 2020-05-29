using System;
using System.Device.Gpio;

namespace TestApp
{
    class Program
    {
        private static readonly GpioController Controller = new GpioController();
        
        static void Main()
        {
            Controller.OpenPin(1, PinMode.Input);
            Controller.OpenPin(2, PinMode.Output);
            Controller.RegisterCallbackForPinValueChangedEvent(1, PinEventTypes.None, Callback);
            
            Console.ReadLine();
            
            Controller.UnregisterCallbackForPinValueChangedEvent(1, Callback);
            Controller.Dispose();
        }

        private static void Callback(object sender, PinValueChangedEventArgs args)
        {
            Console.WriteLine($"Received '{args.ChangeType}' signal on pin '{args.PinNumber}'");
        }
    }
}