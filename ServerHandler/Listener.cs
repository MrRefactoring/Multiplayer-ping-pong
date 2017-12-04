using System;
using System.Net;
using System.Net.Sockets;
using ServerHandler.API;
using ServerHandler.Exceptions;
using ServerHandler.Interfaces;

namespace ServerHandler
{
    public class Listener
    {

        // Присвоить значение переменным readonly можно только при непосредственном объявлении или в конструкторе
        private readonly string _host = "localhost";  // Хост сервера. Изначально localhost
        private readonly int _port = 9090;  // Порт сервера. Изначально 9090
        private readonly int _listenNumber = 2;  // Сколько игроков может вмещать сервер одновременно

        public Listener(){}  // Пустой конструктор. Нужен, если сервер запускается на localhost:9090
        
        public Listener(string host, int port, int listenNumber = 2)
        {
            _host = host;
            _port = port;
            _listenNumber = listenNumber;
        }
        
        private Socket bind()  // Метод конфигурирования сервера
        {
            IPAddress ip = Dns.GetHostEntry(_host).AddressList[0];  // Создаем экземпляр IP адреса
            IPEndPoint endPoint = new IPEndPoint(ip, _port);
            Socket socket = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socket.Bind(endPoint);
                socket.Listen(_listenNumber);  // Сколько игроков может вместить сервер
            }
            catch (SocketException e)
            {
                throw new ServerNotBindedException(e.ToString());  // Вызываем собственное исключение
            }

            return socket;
        }

        public void longPooling(Action<Player, Player> gameGround)  // Передаем функцию, которая запустит gameground
        {
            Socket mainSocket = bind();  // Конфигурируем сервер
            Player firstPlayer = null;  // Сокет для игрока, который находится в очереди и ждет второго игрока
            while (true)  // Бесконечная прослушка _host:_port
            {
                if (firstPlayer == null) // Если нет игроков ожидающих сессии
                {
                    firstPlayer = new Player(mainSocket.Accept());  // Принимаем подключение и ставим в очередь
                    firstPlayer.send("wait");  // Отправляем, чтобы ждал второго игрока
                    Console.WriteLine("Player {0} connected", firstPlayer.name());
                }
                else
                {
                    Player secondPlayer = new Player(mainSocket.Accept());
                    gameGround(firstPlayer, secondPlayer);
                    Console.WriteLine("Player {0} connected", secondPlayer.name());
                    Console.WriteLine("Game run!");
                }
            }
        }
    }
}