using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test");
            Monitor m = new Monitor();
            m.monitor_main();
            Console.ReadKey();
        }
    }
}
