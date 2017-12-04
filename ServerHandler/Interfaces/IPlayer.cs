using Newtonsoft.Json.Linq;

namespace ServerHandler.Interfaces
{
    public interface IPlayer
    {

        JObject info();
        
        void send(string message);
        string read();
        string name();
        bool connected();
    }
}