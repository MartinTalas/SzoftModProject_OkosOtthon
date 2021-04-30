using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace SmartHome
{
    class Controller
    {
        private Loader loader = new Loader();
        private Subscribers subscribers = new Subscribers();
        private Timer refresher=new Timer();
        private IMonitor monitor = new Monitor();
        private IDriver driver = new Driver();

        public Controller()
        {
            this.subscribers = this.loader.loadSubscribers();

            refresher.Interval = 300000;
            //refresher.Interval = 5000;
            refresher.Elapsed += new ElapsedEventHandler(monitorReqest);
            monitorReqest();
            refresher.Start();
        }
        private void monitorReqest(object s,ElapsedEventArgs e)
        {
            monitorReqest();
        }
        private void monitorReqest()
        {
            foreach (Subscriber sub in subscribers.subscribers)
            {
                Session session = monitor.getSession(sub.homeId);
                //string[] split = t.period.Split('-');
                //int start = Convert.ToInt32(split[0]);
                //int end = Convert.ToInt32(split[1]);
                int min = Convert.ToInt32(DateTime.Now.ToString("mm"));
                int hour = Convert.ToInt32(DateTime.Now.ToString("HH"));
                foreach (Temperature t in sub.temperatures)
                {
                    string[] split = t.period.Split('-');
                    int start = Convert.ToInt32(split[0]);
                    int end = Convert.ToInt32(split[1]);

                    if (start <= hour && hour < end)
                    {
                        Console.WriteLine("period:{0}", t.period);
                        Console.WriteLine("Elvart:{0}°C Mostani:{1}°C", t.temperature, session.temperature);
                        double diff = Math.Abs(t.temperature - session.temperature);
                        if(diff> (t.temperature*0.20))
                        {
                            Console.WriteLine("Hiba a rendszerben");
                        }
                        else if (diff > 0.2)
                        {
                            if (t.temperature > session.temperature)
                            {
                                Console.WriteLine("Aircon--");
                                Console.WriteLine("Kazan++");
                                Console.WriteLine(driver.sendCommand(sub, true, false));
                            }
                            if (t.temperature < session.temperature)
                            {
                                Console.WriteLine("Aircon++");
                                Console.WriteLine("Kazan--");
                                Console.WriteLine(driver.sendCommand(sub, false, true));
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nincs szükség beavatkozásra");
                        }
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
