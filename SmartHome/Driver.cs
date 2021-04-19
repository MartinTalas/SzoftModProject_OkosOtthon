using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net;
using System.IO;

namespace SmartHome
{
    class Driver : IDriver
    {
        
        Dictionary<String, Device> deviceMap = new Dictionary<String, Device>();

        Driver()
        {
            deviceMap.Add("Boiler 1200W", new Device("Boiler 1200W","bX3434", "bX1232"));
            deviceMap.Add("Boiler p5600", new Device("Boiler 1200W", "cX7898", "cX3452"));

            deviceMap.Add("Air p5600", new Device("Boiler 1200W", "bX5676", "bX3421"));
            deviceMap.Add("Air c320", new Device("Boiler 1200W", "cX3452", "cX5423"));
        }

        class Command
        {
            public string homeId { get; set; }
            public string boilerCommand { get; set; }
            public string airConditionerCommand { get; set; }

            public Command(string homeId, string boilerCommand,string airConditionerCommand)
            {
                this.homeId = homeId;
                this.boilerCommand = boilerCommand;
                this.boilerCommand = airConditionerCommand;
            }
        }

        public class WeatherForecast
        {
            public DateTimeOffset Date { get; set; }
            public int TemperatureCelsius { get; set; }
            public string Summary { get; set; }
        }

        public int sendCommand(Subscriber subs, bool boiler, bool ac)
        {
            string boilerCommand; 
            string airConditionerCommand;

            if (boiler)
            {
                boilerCommand = deviceMap[subs.boilerType].commandTurnOn;
            }
            else
            {
                boilerCommand = deviceMap[subs.boilerType].commandTurnOff;
            }

            if (ac)
            {
                airConditionerCommand = deviceMap[subs.airConditionerType].commandTurnOn;
            }
            else
            {
                airConditionerCommand = deviceMap[subs.airConditionerType].commandTurnOff;
            }

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://193.6.19.58:8182/smarthome/"+subs.homeId);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            var command = new Command(subs.homeId, boilerCommand, airConditionerCommand);
            string jsonString = JsonSerializer.Serialize(command);

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var res = streamReader.ReadToEnd();
                Console.WriteLine("Eredmenyet:"+res);
                return Convert.ToInt32(res);
            }
        }
    }
}
