using System;

namespace Timer
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer();

            Alarm alarm = new Alarm();
            alarm.Subscribe(timer);

            timer.SetTimer(5);
            timer.StartCountDown();

            Console.ReadKey();
        }
    }
}
