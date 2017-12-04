using Server.API;

namespace Server
{
    internal class Server
    {
        public static void Main(string[] args)
        {
            new GameManager();  // Стартуем сервер
        }
    }
}