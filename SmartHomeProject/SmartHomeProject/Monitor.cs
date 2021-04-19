using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace SmartHomeProject
{
    class Monitor
    {
        public void monitor_main()
        {
            WebRequest request = WebRequest.Create("http://193.6.19.58:8182/smarthome/KD34AF24DS");

            request.Credentials = CredentialCache.DefaultCredentials;

            WebResponse response = request.GetResponse();

            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            using (Stream dataStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream);

                string responseFromServer = reader.ReadToEnd();

                Console.WriteLine(responseFromServer);
            }

            response.Close();
        }
    }
}
