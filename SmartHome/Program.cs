using System;

namespace SmartHome
{
    class Program
    {
        static void Main(string[] args)
        {
            Monitor m = new Monitor();

            Session k = m.getSession("KD34AF24DS");

            Console.WriteLine(k.sessionId);
            Console.WriteLine(k.temperature);
            Console.WriteLine(k.boilerState);
            Console.WriteLine(k.airConditionerState);
            
            http://193.6.19.58:8182/smarthome/%7bhomeId%7d

            Driver d = new Driver();

            Loader debug_loader = new Loader();
            Subscribers debug_subscribers = debug_loader.loadSubscribers();


            d.sendCommand(debug_subscribers.subscribers[0], true, false);

            Console.ReadKey();
            
        }
    }
}
