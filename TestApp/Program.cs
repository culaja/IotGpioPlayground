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
}