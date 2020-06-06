using System;
using System.Device.Gpio;

namespace TestApp
{
    class Program
    {
        private const int InputPin = 17;
        private const int OutputPin = 18;
        
        private static readonly GpioController Controller = new GpioController();

        static void Main()
        {
			Console.WriteLine("Listening on GPIO ports ...");
			
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