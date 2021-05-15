using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SmartHome
{
    class Logger
    {
        
        public Logger() { }

        public void save(double first, double second)
        {
            try
            {
                StreamWriter stream = new StreamWriter("logs.txt", true);
                stream.WriteLine("Dátum: {0}\tElvárt hőmérséklet: {1}°C\tKapott hőmérséklet: {2}°C", DateTime.Now.ToString(), first, second);
                stream.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: [LOG]: {0}", e.Message);
            }
        }
    }
}
