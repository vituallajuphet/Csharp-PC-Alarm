using System;
using System.Diagnostics;
using System.Linq;
using System.Timers;
using System.Runtime.InteropServices; 


namespace securityalarm
{
    class Program
    {
        private static Timer aTimer;

        static void Main(string[] args)
        {   
            string accountSid ="ACfe0887a8af81c5932450f90c86282412";
            string authToken = "28484bfb7a88bcf06fd2ab107efe548f";
            string myNumber = "+12182617400";    
        
            var sms = new Sms(accountSid, authToken, myNumber);
            sms.msgBody = "Hey Juphet, your computer is running... \n\n Running Applications: ";
            sms.tonumber = "+6309058927403";
            
            // get running process of computer...
            var processes = Process.GetProcesses()
            .Where(p => (long)p.MainWindowHandle != 0)
            .ToArray();

            foreach (var p in processes)
            {
                string appName = p.ToString().Replace("System.Diagnostics.Process ", "");
                sms.msgBody += "\n"+appName;
            }

            // send notification
            var response =  sms.sendSms();

            if(response.Status.ToString() == "queued"){
                Console.WriteLine("sent...");
            }

            Console.WriteLine("Sent..");
            // run timer
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

            Console.WriteLine("Time elapsed: {0}", e.SignalTime);
        }

        // logoff 
        [DllImport("user32")]
        public static extern void LockWorkStation();
    }
}
