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

            Loader loader = new Loader();
            Subscribers subscribers = loader.loadSubscribers();
            Console.WriteLine(loader.ToString());

            Console.ReadKey();
            
        }
    }
}
