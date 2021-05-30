using System;
using System.Diagnostics;
using System.Linq;
using System.Timers;


namespace securityalarm
{
    class Program
    {
        private static Timer aTimer;

        static void Main(string[] args)
        {   
            string accountSid ="ACfe0887a8af81c5932450f90c86282412";
            string authToken = "56f7167f062575fc838ad777dacccad4";
            string myNumber = "+12182617400";    
        
            var sms = new Sms(accountSid, authToken, myNumber);
        
            string toNumber = "+639058927403";
            string smsBody = "Hey Juphet, your test is on. \n\nRunning Application:";

            
            var processes = Process.GetProcesses()
            .Where(p => (long)p.MainWindowHandle != 0)
            .ToArray();

            foreach (var p in processes)
            {
                string appName = p.ToString().Replace("System.Diagnostics.Process ", "");

                smsBody += "\n"+appName;
            }

            // var message = sms.sendSms(smsBody, toNumber);

            runTimer();


            Console.Read();
        }

        private static void runTimer () {
            aTimer = new Timer();
            aTimer.Interval = 2000;

            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;

            // Have the timer fire repeated events (true is the default)
            aTimer.AutoReset = true;

            // Start the timer
            aTimer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine("The Elapsed event was raised at {0}", e.SignalTime);
        }

    }
}
