using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Server.API
{
    public class Config
    {
        private readonly JObject config;

        public Config()
        {
            config = JObject.Parse(loadConfigFile());
        }

        public double ballSpeed
        {
            get
            {
                return (double) config["ballSpeed"];
            }
        }

        private string loadConfigFile()
        {
            string[] configFile = File.ReadAllLines("../config.json");
            StringBuilder json = new StringBuilder();
            foreach (string line in configFile)
            {
                json.Append(line);
            }
            return json.ToString();
        }
        
    }
}