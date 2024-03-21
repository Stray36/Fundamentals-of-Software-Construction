using System;
using System.Threading;

namespace Task2
{
    public delegate void ClockSimulator(object sender, ClockEventArgs args);

    public class ClockEventArgs
    {
        public int hour {  get; set; }
        public int minute { get; set; }
        public int second { get; set; }

        public bool IsEqual(ClockEventArgs args)
        {
            return hour == args.hour && minute == args.minute && second == args.second;
        }
        public void PassOneSecond()
        {
            second++;
            if (second == 60)
            {
                minute++;
                second = 0;
            }
            if (minute == 60)
            {
                hour++;
                minute = 0;
            }
            if (hour == 24)
            {
                hour = 0;
            }
        }
    }
    
    public class ClockPublisher
    {

        public event ClockSimulator Tick;
        public event ClockSimulator Alarm;

        public void start(ClockEventArgs tickArgs, ClockEventArgs alarmArgs, int tickSeconds)
        {
            for (int i = 0; i < tickSeconds; i++)
            {
                ClockTick(tickArgs, tickSeconds);
                if (tickArgs.IsEqual(alarmArgs))
                {
                    ClockAlarm(alarmArgs);
                }
                System.Threading.Thread.Sleep(1000);
                tickArgs.PassOneSecond();
            }
        }

        public void ClockTick(ClockEventArgs args, int tickSeconds)
        {
            Tick(this, args);
        }

        public void ClockAlarm(ClockEventArgs args)
        {
            Alarm(this, args);
        }

    }


    public class ClockSubscriber
    {
        public ClockPublisher clock = new ClockPublisher();

        public ClockSubscriber() 
        {
            clock.Tick += Sub_Tick;
            clock.Alarm += Sub_Alarm;
        }

        void Sub_Tick(object sender, ClockEventArgs args)
        {
            Console.WriteLine($"Tick.. {args.hour}:{args.minute}:{args.second}");
        }

        void Sub_Alarm(object sender, ClockEventArgs args)
        {
            Console.WriteLine($"Alarm! {args.hour}:{args.minute}:{args.second}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ClockSubscriber clock1 = new ClockSubscriber();
            ClockEventArgs tickArgs = new ClockEventArgs()
            {
                hour = 16,
                minute = 24,
                second = 36
            };
            ClockEventArgs alarmArgs = new ClockEventArgs()
            {
                hour = 16,
                minute = 24,
                second = 40
            };
            clock1.clock.start(tickArgs, alarmArgs, 10);
        }
    }
}