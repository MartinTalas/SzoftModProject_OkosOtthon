using System;

namespace SmartHome
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Meleg vagy!");
            Monitor m = new Monitor();
            Console.WriteLine(m.getSession("KD34AF24DS"));
        }
    }
}
