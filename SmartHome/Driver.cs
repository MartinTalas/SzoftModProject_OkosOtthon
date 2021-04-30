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
        [Serializable]
        public class BadInputException : Exception 
        {
            const string msg="HIBA: A driver bemeneti fályla nem megfelelő formátomu";
            public BadInputException():base(msg)
            {
                
            }
            public BadInputException(string missing) : base(msg+": "+missing+"-hiányzik\n")
            {

            }
            public BadInputException(string missing,string device) : base(msg + ": " + missing + "-hiányzik a(z)"+device+"-nak\n")
            {

            }
        }

        public Driver()
        {
            /*
            deviceMap.Add("Boiler 1200W", new Device("Boiler 1200W", "bX3434", "bX1232"));
            deviceMap.Add("Boiler p5600", new Device("Boiler p5600", "cX7898", "cX3452"));
            deviceMap.Add("Boiler tw560", new Device("Boiler tw560", "dX3422", "dX111"));
            deviceMap.Add("Boiler 1400L", new Device("Boiler tw560", "kx8417", "kx4823"));

            deviceMap.Add("Air p5600", new Device("Air p5600", "bX5676", "bX3421"));
            deviceMap.Add("Air c320", new Device("Air c320", "cX3452", "cX5423"));
            deviceMap.Add("Air rk110", new Device("Air rk110", "eX1111", "eX2222"));
            */
            StreamReader stream = new StreamReader("devices.txt");
            stream.ReadLine();
            int sor=0;
            while (!stream.EndOfStream)
            {
                string line = stream.ReadLine();
                if (line != String.Empty && !line.Contains(":"))
                {
                    string start = stream.ReadLine();
                    string stop = stream.ReadLine();

                    if (start.Contains("START") && stop.Contains("STOP"))
                    {
                        line = line.Trim().Trim('"');
                        start = start.Split(',')[1].Trim().Trim('"');
                        stop = stop.Split(',')[1].Trim().Trim('"');
                        deviceMap.Add(line, new Device(line, start, stop));
                    }
                    else
                    {
                        if (!start.Contains("START"))
                        {
                            throw new BadInputException("START",line);
                        }    
                        if(!stop.Contains("STOP"))
                        {
                            throw new BadInputException("STOP", line);
                        }
                    }
                }
                sor++;
            }
            /*
            foreach(string key in deviceMap.Keys)
            {
                Console.WriteLine("{0}: Start:{1}, Stop:{2}",key, deviceMap[key].commandTurnOn, deviceMap[key].commandTurnOff);
            }
            */
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
            string boilerCommand=""; 
            string airConditionerCommand="";

            if (subs.boilerType != String.Empty)
            {
                if (boiler)
                {
                    boilerCommand = deviceMap[subs.boilerType].commandTurnOn;
                }
                else
                {
                    boilerCommand = deviceMap[subs.boilerType].commandTurnOff;
                }
            }

            if(subs.airConditionerType!=String.Empty)
            {
                if (ac)
                {
                    airConditionerCommand = deviceMap[subs.airConditionerType].commandTurnOn;
                }
                else
                {
                    airConditionerCommand = deviceMap[subs.airConditionerType].commandTurnOff;
                }
            }
            

            string url = "http://193.6.19.58:8182/smarthome/" + subs.homeId;
            WebRequest request = WebRequest.Create(url);
            request.ContentType = "text/plain";
            request.Method = "POST";

            string json_string =JsonSerializer.Serialize(new Command(subs.homeId, boilerCommand, airConditionerCommand));
            //Console.WriteLine(json_string);

            using (var stream = request.GetRequestStream())
            {
                stream.Write(Encoding.UTF8.GetBytes(json_string), 0, Encoding.UTF8.GetBytes(json_string).Length);
            }

            StreamReader result;
            int resultint = 404;
            HttpWebResponse httpResponse;
            try
            {
                httpResponse = (HttpWebResponse)request.GetResponse();
                
                result = new StreamReader(httpResponse.GetResponseStream());
                resultint = Convert.ToInt32(result.ReadToEnd());
            }
            catch (WebException ex)
            {
                httpResponse = (HttpWebResponse)ex.Response;
                //Console.WriteLine((HttpWebResponse)ex.Response);
            }
            return resultint;
        }
    }
}
