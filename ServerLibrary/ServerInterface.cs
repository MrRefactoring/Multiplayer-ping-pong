using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibrary
{
    interface ServerInterface
    {

        void bind(string host, int port);  // Метод для биндинга сервера

        void listenLoop();  // Слушатель входящих подключений

    }
}
