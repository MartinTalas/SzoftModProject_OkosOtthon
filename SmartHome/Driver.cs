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

        public Driver()
        {
            deviceMap.Add("Boiler 1200W", new Device("Boiler 1200W", "bX3434", "bX1232"));
            deviceMap.Add("Boiler p5600", new Device("Boiler p5600", "cX7898", "cX3452"));
            deviceMap.Add("Boiler tw560", new Device("Boiler tw560", "dX3422", "dX111"));

            deviceMap.Add("Air p5600", new Device("Air p5600", "bX5676", "bX3421"));
            deviceMap.Add("Air c320", new Device("Air c320", "cX3452", "cX5423"));
            deviceMap.Add("Air rk110", new Device("Air rk110", "eX1111", "eX2222"));
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
                this.airConditionerCommand = airConditionerCommand;
            }
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

            string url = "http://193.6.19.58:8182/smarthome/" + subs.homeId;
            WebRequest request = WebRequest.Create(url);
            request.ContentType = "text/plain";
            request.Method = "POST";

            string ujkefdrgtbhjnmfgkv=JsonSerializer.Serialize(new Command(subs.homeId, boilerCommand, airConditionerCommand));
            Console.WriteLine(ujkefdrgtbhjnmfgkv);

            using (var stream = request.GetRequestStream())
            {
                stream.Write(Encoding.UTF8.GetBytes(ujkefdrgtbhjnmfgkv), 0, Encoding.UTF8.GetBytes(ujkefdrgtbhjnmfgkv).Length);
            }

            HttpWebResponse httpResponse;
            try
            {
                httpResponse = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                httpResponse = (HttpWebResponse)ex.Response;
            }

            return 404;
        }
    }
}
