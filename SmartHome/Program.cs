using System;

namespace SmartHome
{
    class Program
    {
        static void Main(string[] args)
        {
            Loader debug_loader = new Loader();
            Subscribers debug_subscribers = new Subscribers();
            debug_subscribers = debug_loader.loadSubscribers();
            Console.WriteLine(debug_loader.ToString());
        }
    }
}
