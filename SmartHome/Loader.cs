using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace SmartHome
{
    class Loader : ILoader
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
            loaded_subscribers = JsonSerializer.Deserialize<Subscribers>(jsonString);
        }
    }
}
