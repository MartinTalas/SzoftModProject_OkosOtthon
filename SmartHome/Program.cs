using System;

namespace SmartHome
{
    public class Program
    {
        static void Main(string[] args)
        {
            Monitor m = new Monitor();

            Session k = m.getSession("KD34AF24DS");

            Console.WriteLine(k.sessionId);
            Console.WriteLine(k.temperature);
            Console.WriteLine(k.boilerState);
            Console.WriteLine(k.airConditionerState);
            
            //http://193.6.19.58:8182/smarthome/%7bhomeId%7d

            Driver d = new Driver();

            Loader debug_loader = new Loader();
            Subscribers debug_subscribers = debug_loader.loadSubscribers();


            Console.WriteLine(d.sendCommand(debug_subscribers.subscribers[0], true, true));

            //DEBUG
            //Console.WriteLine(debug_loader.ToString());
            Controller c = new Controller();
            Console.ReadKey();
            
        }
    }
}
