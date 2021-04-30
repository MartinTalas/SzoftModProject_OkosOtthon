using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace SmartHome
{
    public class Loader : ILoader
    {
        private const string file_name = "subscriberdata.json";
        private Subscribers loaded_subscribers = new Subscribers();
        public Subscribers loadSubscribers()
        {
            this.loadFromJson();
            return this.loaded_subscribers;
        }

        private void loadFromJson()
        {
            string jsonString = File.ReadAllText(file_name);
            this.loaded_subscribers = JsonSerializer.Deserialize<Subscribers>(jsonString);
        }

        public override string ToString()
        {
            string result = "";
            foreach (Subscriber element in loaded_subscribers.subscribers)
            {
                result += "[ Subscriber: " + element.subscriber + " with home ID: " + element.homeId+ " ]\n";
            }
            return result;
       }
    }
}
