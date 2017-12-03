using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerLibrary.Exceptions;
using System.Net.Sockets;
using System.Net;

namespace ServerLibrary
{
    public class ServerHandler: ServerInterface {

        protected Socket socket = null;  // Сокет сервера
        protected Socket user = null;  // Сокет для игрока, который подключится первый

        public void bind(string host, int port)
        {
            IPAddress ip = Dns.GetHostEntry(host).AddressList[0];
            IPEndPoint endPoint = new IPEndPoint(ip, port);
            socket = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socket.Bind(endPoint);
                socket.Listen(5);
            } catch (Exception e)
            {
                throw e;
            }
        }

        public virtual void listenLoop()  // Метод который слушает входящие подключения
        {

            if (socket == null)
            {
                throw new ServerNotBinded();  // Если сервер не сконфигурирован, то вызываем искл
            }
        }

    }
}
