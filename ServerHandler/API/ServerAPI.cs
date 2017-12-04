using System.Net.Sockets;
using System.Text;

namespace ServerHandler.API
{
    public class ServerAPI
    {
        public static void send(string message, Socket socket)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message);  // Получаем байты из сообщения
            socket.Send(buffer);
        }

        public static string read(Socket socket)
        {
            StringBuilder result = new StringBuilder();
            byte[] buffer = new byte[10000000];
            int length = socket.Receive(buffer);  // Читаем буфер
            for (int i = 0; i < length; i++)
            {
                result.Append(buffer[i]);
            }
            return result.ToString();
        }
    }
}