using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace SmartHome
{
    class Monitor:IMonitor
    {
        private const char V = '}';

        public Session getSession(string home_id)
        {
            WebRequest request = WebRequest.Create("http://193.6.19.58:8182/smarthome/" + home_id);

            request.Credentials = CredentialCache.DefaultCredentials;

            WebResponse response = request.GetResponse();

            //Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            string responseFromServer;

            using (Stream dataStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream);

                responseFromServer = reader.ReadToEnd();

                //Console.WriteLine(responseFromServer);
            }

            response.Close();

            Session s = new Session();
            string[] bemenet = responseFromServer.Split(",");
            
            List<String> bemenet_2 = new List<String>();
            for (int i = 0;i < 4;i++)
            {
                bemenet_2.Add(bemenet[i].Split(':')[1]);
            }

            s.sessionId = bemenet_2[0].Trim('"');
            s.temperature = Convert.ToDouble(bemenet_2[1].Replace(".", ","));
            s.boilerState = Convert.ToBoolean(bemenet_2[2]);
            s.airConditionerState = Convert.ToBoolean(bemenet_2[3].Trim(V));
            
            return s;
        }
    }
}
