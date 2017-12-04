using System;
using System.Net.Sockets;
using Newtonsoft.Json.Linq;
using ServerHandler.Interfaces;

namespace ServerHandler.API
{
    public class Player: IPlayer
    {

        private readonly string _name;  // Имя игрока

        private readonly Socket _socket;

        public Player(Socket socket)
        {
            if (socket == null)
            {
                throw new NullReferenceException("Socket have nullPointer");
            }
            _socket = socket;
            _name = name();
            socket.Blocking = false;  // Делаем сокет неблокирующим
            socket.SendTimeout = 100;  // Максимум 100 милисек ждем
            socket.ReceiveTimeout = 100;  // Максимум 100 милисек ждем
        }

        public JObject info()
        {
            return JObject.Parse(read());  // Читаем информацию из сокета
        }

        public void send(string message)  // Метод для отправки сообщений игроку
        {
            ServerAPI.send(message, _socket);
        }

        public string read()  // Метод для чтения буфера из сокета
        {
            return ServerAPI.read(_socket);
        }

        public string name()  // Метод возвращающий имя
        {
            return _name ?? read();
        }

        public bool connected()
        {
            return _socket.Connected;
        }
        
    }
}